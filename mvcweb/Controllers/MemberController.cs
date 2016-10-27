using System;
using System.Web.Mvc;
using mvcweb.Filters;
using Model;
using Service;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Model.ViewModel;
using System.Web.Script.Serialization;

namespace mvcweb.Controllers
{
    public class MemberController : BaseController
    {
        MemberService memberService = new MemberService();

        public ActionResult Member()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

        public ActionResult TeacherMember()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

        public ActionResult NoopsycheOrder()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

        #region 我的卡次
        /// <summary>
        /// 我的卡次
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMyCourseCard()
        {
            return Json(memberService.GetMyCourseCard(member.Id));
        }
        #endregion

        #region 我的课程

        /// <summary>
        /// 获取上课计划
        /// </summary>
        /// <returns></returns>
        public ActionResult GetClassPlan(int classType, int queryType, int courseType, int classId = 0)
        {
            if (classType == 0)
            {
                var a = memberService.GetCourseCard(member.Id, queryType, courseType);
                //a.Result.

                return Json(a);
            }
            else
                return Json(memberService.GetCourseCard(member.Id, queryType, classId, courseType));
        }

        /// <summary>
        /// 一对多 加入课程
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InsertCourse(int planId, int classId)
        {
            return Content(Common.GetRequestConent(SsoKey.GetKey(memberService.GetMember(member.Id).Result), Common.AddtoCourseUrl, "{\"CplId\":\"" + planId + "\",\"ClassId\":\"" + classId + "\"}"));
        }

        /// <summary>
        /// 添加评价
        /// </summary>
        /// <param name="classComment"></param>
        /// <returns></returns>
        public ActionResult CreateClassComment(ClassComment classComment)
        {
            classComment.MemberId = member.Id.ToString();
            classComment.CreateTime = DateTime.Now;
            bool isPublicCourse = classComment.CommentType >= 100;
            try
            {
                if (member.Type != 1)
                {
                    classComment.TeacherId = memberService.GetTeacherByMemberId(member.Id).TeacherId;
                }
            }
            catch (Exception ex)
            {

            }
            classComment.CommentType = member.Type == 1 ? 0 : 1;
            return Json(memberService.CreateClassComment(classComment, isPublicCourse));
        }

        /// <summary>
        /// 获取评价
        /// </summary>
        /// <param name="cplId"></param>
        /// <returns></returns>
        public ActionResult GetLessonComment(int cplId, bool isPublic)
        {
            return Json(memberService.GetLessonComment(cplId, member.Id, isPublic));
        }

        /// <summary>
        /// 取消预约
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CancelYuyue(int planId, int categoryCode)
        {
            try
            {
                return Content(Common.GetRequestConent(SsoKey.GetKey(memberService.GetMember(member.Id).Result), Common.CancelOrderUrl, "{\"CategoryCode\":" + categoryCode + ",\"CplId\":" + planId + "}"));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }

        /// <summary>
        /// 视频列表
        /// </summary>
        /// <param name="CplId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetVideoAccess(int cplId, int courseType)
        {
            //这个地方要判断是否是公开课还是自约课
            if (courseType == 1)//公开课
            {
                var res = new Response<string>();
                res.Result = new GenSeeService().GetUrl(cplId);
                return Json(res);
            }
            else//自约课
            {
                var res = new Response<List<VideoListModel>>();
                var ret = Common.GetRequestConent(SsoKey.GetKey(memberService.GetMember(member.Id).Result), Common.VideoAccessoryUrl, "{\"CplId\":\"" + cplId + "\",\"CourseType\":\"" + courseType + "\"}");
                var tempmodel = new JavaScriptSerializer().Deserialize<VideoInfoObject>(ret);
                if (tempmodel.Data != null && tempmodel.Data.Count > 0)
                {
                    res.Result = new List<VideoListModel>();
                    try
                    {
                        tempmodel.Data.ForEach(c =>
                        {
                            var model = new VideoListModel();
                            model.RecordStartTime = c.RecordStartTime;
                            //  url = string.Format("{0}?nickName={1}&token={2}", jr["Data"]["Url"].ToString(), jr["Data"]["Id"].ToString(), jr["Data"]["PASSWORD"].ToString());
                            model.DataUrl = string.Format("{0}?nickName={1}&token={2}", c.Url, c.Id, c.PASSWORD);
                            res.Result.Add(model);
                        });
                    }
                    catch (Exception ex)
                    { 
                    }
                }
                return Json(res);
            }
        }

        /// <summary>
        /// 下载课件
        /// </summary>
        /// <param name="CplId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetLessonAccess(string CplId)
        {
            try
            {
                return Content(Common.GetRequestConent(SsoKey.GetKey(memberService.GetMember(member.Id).Result), Common.LessonAccessoryUrl, "{\"CplId\":" + CplId + "}"));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }

        /// <summary>
        /// 公开课取消占座
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public ActionResult CancelHold(int classId)
        {
            Response<bool> res = memberService.CancelHold(classId, member.Id);
            return Json(res);
        }
        #endregion

        #region 智能约课
        /// <summary>
        /// 获取上课老师
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public ActionResult GetClassTeacher(int classId)
        {
            return Json(memberService.GetClassTeacher(classId));
        }

        /// <summary>
        /// 获取课程老师时段
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="TeacherId"></param>
        /// <param name="BookDate"></param>
        /// <param name="CourseCount"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetCourseTeachers(int courseId, int classId, string teacherIds, string bookDate, int courseCount)
        {
            try
            {
                var coursestring = Common.GetRequestConent(SsoKey.GetKey(memberService.GetMember(member.Id).Result), Common.CapacityUrl, "{\"MemberId\":\"" + member.Id + "\",\"CourseId\":\"" + courseId + "\",\"ClassId\":\"" + classId + "\",\"BookDate\":\"" + bookDate + "\",\"CourseCount\":" + courseCount + ",\"TeacherId\":\"" + teacherIds + "\"}");
                return Content(coursestring);

            }
            catch (Exception ex)
            {
                return Content("");
            }
        }

        /// <summary>
        /// 提交课程预约
        /// </summary>
        /// <returns></returns>
        public ActionResult Order(int courseId, string teacherIds, string bookDate, int courseCount, string beginTime, int classId)
        {
            var coursestring = Common.GetRequestConent(SsoKey.GetKey(memberService.GetMember(member.Id).Result), Common.CommitCapacityUrl, "{\"MemberId\":\"" + member.Id + "\",\"CourseId\":\"" + courseId + "\",\"ClassId\":\"" + classId + "\",\"BookDate\":\"" + bookDate + "\",\"BeginTime\":\"" + beginTime + "\",\"CourseCount\":" + courseCount + ",\"TeacherIds\":\"" + teacherIds + "\"}");
            return Content(coursestring);
        }
        #endregion

        #region 修改密码
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="newpwd"></param>
        /// <param name="confirmpwd"></param>
        /// <returns></returns>
        public ActionResult UpdatePassword(string pwd, string newpwd)
        {
            return Json(memberService.UpdatePassword(member.Id, Common.Encrypt(pwd), Common.Encrypt(newpwd)));
        }
        #endregion

        #region 修改绑定手机号
        public ActionResult UpdatePhone(string phone, string code)
        {
            var res = new Response<bool>();
            if (Session["uuid"] == null)
            {
                res.ErrMsg = "获取验证码失败！请重试";
            }
            else
            {
                try
                {
                    res = memberService.UpdatePhone(member.Id, phone, code, Session["uuid"].ToString());
                }
                catch (Exception ex)
                {
                    res.ErrMsg = "修改绑定手机号失败！";
                    LogError(string.Format("用户{0}修改绑定手机号出错：{1}", member.Id, ex.Message.ToString()).ToString());
                }
            }
            return Json(res);
        }
        #endregion

        #region 我的课表

        /// <summary>
        /// 获取课表
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public ActionResult GetSchedule(DateTime beginTime)
        {
            return Json(new Response<List<MemberSchedule>> { Result = memberService.GetSchedule(member.Id, 1, member.Type).Result.Concat(memberService.GetSchedule(member.Id, 0, member.Type).Result).Concat(memberService.GetSchedule(member.Id, -1, member.Type).Result).ToList() });
        }

        public ActionResult GetScheduleByMonth(int month)
        {
            return Content(JsonConvert.SerializeObject(memberService.GetSchedule(member.Id, month, member.Type)));
        }



        #endregion

        #region 个人信息
        public ActionResult GetMember()
        {
            return Json(memberService.GetMember(member.Id));
        }

        public ActionResult SaveMember(Member member)
        {
            member.Id = this.member.Id;
            member.Address = member.Address ?? "";
            member.Voice = member.Voice ?? "";
            member.Email = member.Email ?? "";
            return Json(memberService.SaveMember(member));
        }

        public ActionResult ModifyPhoto()
        {
            ViewBag.Path = Request.ApplicationPath == "/" ? "" : Request.ApplicationPath;
            var res = memberService.GetMember(member.Id);
            if (res.IsSuccess)
            {
                var path = res.Result.Logo;
                if (!IsPhoto(path))
                {
                    path = GetBaseVirtualPath + "/Images/member_default.png";
                }
                var files = path.Split('/');
                var name = files[files.Length - 1].Split('_');
                ViewBag.Title = name.Length > 1 ? name[1] : name[0];
                ViewBag.Logo = path;
            }
            return View();
        }

        /// <summary>
        /// 判断是否为图片
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private bool IsPhoto(string url)
        {
            var imgs = ",png,jpg,jpeg,gif,";
            if (!string.IsNullOrEmpty(url))
            {
                var us = url.Split('.');
                return imgs.IndexOf("," + us[us.Length - 1] + ",") > -1;
            }
            else
            {
                return false;
            }
        }

        public ActionResult SavePhoto(FormCollection form)
        {
            //文件大小不为0
            HttpPostedFileBase file = Request.Files[0];
            var size = Request["size"].ToString().Split(',');
            //保存成自己的文件全路径,newfile就是你上传后保存的文件,
            //服务器上的UpLoadFile文件夹必须有读写权限　　　　　　
            //var fileName = "Upload/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + file.FileName.Substring(file.FileName.LastIndexOf("\\") + 1);
            var fileName = file.FileName.Substring(file.FileName.LastIndexOf("\\") + 1);
            ViewBag.Logo = GetBaseVirtualPath + "/Images/member_default.png";
            if (IsPhoto(fileName))
            {
                try
                {
                    fileName = "Upload/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + Path.GetExtension(fileName);
                    using (var bitmap = GenerateThumbnail(1000, 1000, file.InputStream))
                    {
                        var pic = Cut(bitmap, int.Parse(size[0]), int.Parse(size[1]), int.Parse(size[2]), int.Parse(size[3]));
                        pic.Save(Common.BaseFilePath + fileName);
                    }

                    //file.SaveAs(Common.BaseFilePath + fileName);
                    //memberService.UpdatePhoto(member.Id, Common.BaseFilePath + fileName);
                    memberService.UpdatePhoto(member.Id, Common.ServiceUrl + fileName);
                    var files = fileName.Split('/');
                    var name = files[files.Length - 1].Split('_');
                    ViewBag.Title = name.Length > 1 ? name[1] : name[0];
                    ViewBag.Logo = Common.ServiceUrl + fileName;
                }
                catch (Exception ex)
                {
                    LogError(string.Format("用户保存图片出错：{0}", ex.Message.ToString()).ToString());
                }
            }
            // return View("ModifyPhoto");
            return RedirectToAction("ModifyPhoto");
        }

        public ActionResult ChangePwd()
        {
            return View();
        }

        public ActionResult ChangePhone()
        {
            return View();
        }
        #endregion

        private System.Drawing.Bitmap GenerateThumbnail(int maxWidth, int maxHeight, System.IO.Stream imgFileStream)
        {
            using (var img = System.Drawing.Image.FromStream(imgFileStream))
            {
                var sourceWidth = img.Width;
                var sourceHeight = img.Height;

                var thumbWidth = sourceWidth; //要生成的图片的宽度  
                var thumbHeight = sourceHeight; //要生成图片的的高度  

                //计算生成图片的高度和宽度  
                if (sourceWidth > maxWidth || sourceHeight > maxHeight)
                {
                    var rateWidth = (double)sourceWidth / maxWidth;
                    var rateHeight = (double)sourceHeight / maxHeight;

                    if (rateWidth > rateHeight)
                    {
                        thumbWidth = maxWidth;
                        thumbHeight = (int)Math.Round(sourceHeight / rateWidth);
                    }
                    else
                    {
                        thumbWidth = (int)Math.Round(sourceWidth / rateHeight);
                        thumbHeight = maxHeight;
                    }
                }

                var bmp = new System.Drawing.Bitmap(thumbWidth, thumbHeight);
                //从Bitmap创建一个System.Drawing.Graphics对象，用来绘制高质量的缩小图。  
                using (var gr = System.Drawing.Graphics.FromImage(bmp))
                {
                    //设置 System.Drawing.Graphics对象的SmoothingMode属性为HighQuality  
                    gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    //下面这个也设成高质量  
                    gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    //下面这个设成High  
                    gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

                    //把原始图像绘制成上面所设置宽高的缩小图  
                    var rectDestination = new System.Drawing.Rectangle(0, 0, thumbWidth, thumbHeight);
                    gr.DrawImage(img, rectDestination, 0, 0, sourceWidth, sourceHeight,
                                 System.Drawing.GraphicsUnit.Pixel);
                    return bmp;
                }
            }
        }


        public static Bitmap Cut(Bitmap b, int StartX, int StartY, int iWidth, int iHeight)
        {
            if (b == null)
            {
                return null;
            }
            int w = b.Width;
            int h = b.Height;
            if (StartX >= w || StartY >= h)
            {
                return null;
            }
            if (StartX + iWidth > w)
            {
                iWidth = w - StartX;
            }
            if (StartY + iHeight > h)
            {
                iHeight = h - StartY;
            }
            try
            {
                Bitmap bmpOut = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(bmpOut);
                g.DrawImage(b, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
                g.Dispose();
                return bmpOut;
            }
            catch
            {
                return null;
            }
        }




        #region 我的订单
        /// <summary>
        /// 我的订单
        /// </summary>
        /// <returns></returns>
        public ActionResult GetOrders()
        {
            return Json(memberService.GetOrders(member.Id));
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public ActionResult CancelOrder(string orderNo)
        {
            return Json(memberService.CancelOrder(orderNo, member.Id));
        }

        public ActionResult Orders()
        {
            return View();
        }


        #endregion

        #region 我的评价
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetClassComment(int type)
        {
            return Json(memberService.GetClassComment(member.Id, member.Type, type));
        }
        #endregion

        #region 我的疑问
        public ActionResult GetQuestion()
        {
            return Json(memberService.GetQuestion(member.Id));
        }

        public ActionResult RaiseQuestion(string Content)
        {
            return Json(memberService.RaiseQuestion(member.Id, Content));
        }

        /// <summary>
        /// 常见问题
        /// </summary>
        /// <returns></returns>
        public ActionResult CommonQuestion()
        {
            return View();
        }

        public ActionResult GetQuestionAnswer(int Id)
        {
            return Json(memberService.GetQuestionAnswer(Id));
        }

        public ActionResult SetQuestionAnswer(int Id)
        {
            return Json(memberService.SetQuestionAnswer(Id));
        }
        #endregion

        #region 我的答疑
        public ActionResult GetAnswer()
        {
            return Json(memberService.GetAnswer(member.Id));
        }
        #endregion
    }
}