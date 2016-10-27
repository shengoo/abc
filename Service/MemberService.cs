using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using DataBase;
using Model.ViewModel;

namespace Service
{
    public class MemberService
    {
        MemberDao memberDao = new MemberDao();
        CourseCardDao coursecardDao = new CourseCardDao();
        ClassLessonDao classDao = new ClassLessonDao();
        ScheduleDao scheduleDao = new ScheduleDao();
        OrdersDao orderDao = new OrdersDao();
        ClassCommentDao classCommentDao = new ClassCommentDao();
        AnswerDao answerDao = new AnswerDao();
        AskDao askDao = new AskDao();

        PaymentLogDal paymentLogDal = new PaymentLogDal();

        #region 个人信息

        public Response<bool> UpdatePhone(int id, string phone, string code, string uuid)
        {
            var res = new Response<bool>();
            try
            {
                if (ExistMemberValid(phone, uuid, code))//判断手机号是否能正常收到验证码
                {
                    memberDao.Update(new Member { Id = id, Mobile = phone }, new string[] { "Id" }, "Mobile");
                }
                else
                {
                    res.ErrMsg = "验证码无效!请重新获取";
                }
            }
            catch (Exception ex)
            {
                res.ErrMsg = "修改绑定手机号失败!" + ex.Message;
            }
            return res;
        }

        public Response<Member> GetMember(int memberId)
        {
            var res = new Response<Member>();
            try
            {
                res.Result = memberDao.GetModels(" Id=@0", memberId).First();
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取会员信息失败！" + ex.Message;
            }
            return res;
        }

        public Response<bool> CancelHold(int classId, int id)
        {
            var res = new Response<bool>();
            try
            {
                new OpenClassDao().Delete(new OpenClassMember
                {
                    OpenClassId = classId,
                    MemberId = id
                }, "OpenClassId", "MemberId");
            }
            catch (Exception ex)
            {
                res.ErrMsg = "取消预约失败！";
            }
            return res;
        }

        public Response<bool> SaveMember(Member member)
        {
            var res = new Response<bool>();
            try
            {
                memberDao.Update(member, "Id".Split(','), "ENName", "CNName", "Voice", "Sex", "Birthday", "Email", "Address");
            }
            catch (Exception ex)
            {
                res.ErrMsg = "修改会员信息异常！" + ex.Message;
            }
            return res;
        }
        #endregion

        #region 我的课程卡次信息
        /// <summary>
        /// 获取课程卡次信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Response<List<MyCourseCard>> GetMyCourseCard(int userId)
        {
            var res = new Response<List<MyCourseCard>>();
            try
            {
                res.Result = coursecardDao.GetMyCourseCard(userId);
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取课程信息失败！" + ex.Message;
            }
            return res;
        }
        #endregion

        #region 我的课程
        /// <summary>
        /// 获取课程信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Response<List<MyCourse>> GetCourseCard(int userId, int classType, int courseType)
        {
            var res = new Response<List<MyCourse>>();
            try
            {
                res.Result = coursecardDao.GetPactCourse(userId, classType, courseType);
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取课程信息失败！" + ex.Message;
            }
            return res;
        }

        /// <summary>
        /// 获取课次信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Response<List<CourseDetail>> GetCourseCard(int userId, int classType, int classId, int courseType)
        {
            var res = new Response<List<CourseDetail>>();
            try
            {
                var detailsList= coursecardDao.GetPactCourse(userId, classType, classId, courseType);
                //if (classType > 0 && classId > 0)
                //{
                //    if (detailsList != null && detailsList.Count > 0)
                //    {
                //        detailsList = detailsList.OrderByDescending(c => c.ClassDate).ThenByDescending(c => c.EndTime).ToList();
                //    }
                //}
                res.Result = detailsList;
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取课次信息失败！" + ex.Message;
            }
            return res;
        }

        /// <summary>
        /// 获取课程限制上课老师
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public object GetLimitTeacher(int classId)
        {
            return new TeacherDao().ValidLimitTeacher(classId);
        }

        public Teacher GetTeacherByMemberId(int memberId)
        {
            return new TeacherDao().GetModels(" memberId=@0 ", memberId).FirstOrDefault();
        }

        public Response<List<CourseProcess>> GetClassLesson(int classId, int memberId)
        {
            var res = new Response<List<CourseProcess>>();
            try
            {
                res.Result = classDao.GetClassLesson(classId, memberId);
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取课次信息失败！" + ex.Message;
            }
            return res;
        }


        public Response<bool> CreateClassComment(ClassComment classComment, bool isPublicCourse)
        {
            var res = new Response<bool>();
            try
            {
                if (isPublicCourse)
                {
                    classComment.CplId = 0;
                    classComment.TeacherId = classDao.GetClassModels("SELECT TeacherId FROM OpenClass WHERE OpenClassId=@0", classComment.ClassId).First().TeacherId;
                }
                else if (classComment.CommentType == 0)
                {
                    classComment.TeacherId = classDao.GetClassModels("SELECT TeacherId FROM ClassPlanLesson WHERE CplId=@0", classComment.CplId).First().TeacherId;
                }
                classCommentDao.Insert(classComment, "TeacherId", "CommentType", "Content", "ClassId", "CplId", "Rate1", "Rate2", "Rate3", "MemberId", "CreateTime");
            }
            catch (Exception ex)
            {
                res.ErrMsg = "添加评价失败！";
            }
            return res;
        }

        public Orders GetOrderByOrderNo(string orderNo)
        {
            List<Orders> orders = new List<Orders>();
            Orders order = null; 
            orders = orderDao.GetModels("OrderNo=@0 ", orderNo);
            if (orders != null && orders.Count == 1) {
                orders[0] = order;
            }
            return order;  
        }

        public void PaySuccess(string transaction_id, string orderNo, string channel)
        {
            try
            {
                List<Orders> orders = new List<Orders>();
                Orders order = null;
                if (channel.Equals("wx"))
                {
                    orders = orderDao.GetModels("OrderId=@0 and Enabled=@1", Convert.ToInt32(orderNo), 0);
                }
                else
                {
                    orders = orderDao.GetModels("OrderNo=@0 and Enabled=@1", orderNo, 0);
                }

                //  memberDao.GetModels("id=@0 and pwd=@1", memberId, passWord)
                if (orders.Count == 1)
                {
                    order = orders[0];
                    orderDao.Update(new Orders
                    {
                        OrderNo = order.OrderNo,
                        Enabled = 1,
                        TradeNo = transaction_id
                    }, new string[] { "OrderNo" }, "Enabled", "TradeNo");

                    PaymentLog model = new PaymentLog();
                    model.IsPayed = "1";
                    model.PayedTime = DateTime.Now;
                    model.CreateTime = DateTime.Now;
                    model.Payment = channel;
                    model.TradeNo = transaction_id;
                    model.SourceOrderId = order.OrderId;
                    model.Amount = order.TotalAmount;
                    model.MemberId = order.MemberId;
                    string[] paramlist = { "IsPayed", "PayedTime", "CreateTime", "Payment", "TradeNo", "SourceOrderId", "Amount", "MemberId" };
                    paymentLogDal.Insert(model, paramlist);
                    DbHelperSQL.ExcuteNonquery("exec  pro_UpdateOrderExpiryDate  " + order.OrderId ); 
                }
                DbHelperSQL.WriteLog("交易成功\r\n" + "订单号：" + orderNo + " 交易流水号：" + transaction_id, new Exception());
            }
            catch (Exception ex)
            {
                DbHelperSQL.WriteLog("订单状态修改失败\r\n" + "订单号：" + orderNo + " 交易流水号：" + transaction_id, ex);
            }
        }


        /// <summary>
        /// 获取课次评价信息
        /// </summary>
        /// <param name="lessonId"></param>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public Response<ClassComment> GetLessonComment(int cplId, int memberId, bool isPublic)
        {
            var res = new Response<ClassComment>();
            try
            {
                if (isPublic)
                {
                    res.Result = classCommentDao.GetClassModels("select content,rate1,rate2,rate3 from classcomment  where cplid=0 and classid=@0 and memberid=@1", cplId, memberId).FirstOrDefault();
                }
                else
                {
                    res.Result = classCommentDao.GetClassModels("select content,rate1,rate2,rate3 from classcomment  where cplid=@0 and memberid=@1", cplId, memberId).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取课次评价信息失败！" + ex.Message;
            }
            return res;
        }
        #endregion

        #region 修改密码
        public Response<bool> UpdatePassword(int memberId, string passWord, string newPassword, bool isTeacher = false)
        {
            var res = new Response<bool>();
            try
            {
                if (memberDao.GetModels("id=@0 and pwd=@1", memberId, passWord).Count > 0)
                {
                    memberDao.Update(new Member
                    {
                        Id = memberId,
                        Pwd = newPassword
                    }, new string[] { "Id" }, "Pwd");
                }
                else
                {
                    res.ErrMsg = !isTeacher ? "旧密码输入有误！" : "Old password is incorrect";
                }
            }
            catch (Exception ex)
            {
                res.ErrMsg = (!isTeacher ? "修改会员密码失败！" : "Modify password failed") + ex.Message;
            }
            return res;
        }

        public void UpdatePhoto(int id, string v)
        {
            memberDao.Update(new Member
            {
                Id = id,
                Logo = v
            }, new string[] { "Id" }, "Logo");
        }


        #endregion

        #region 首页
        public Response<Member> Login(Member member)
        {
            var res = new Response<Member>();
            try
            {
                var sm = memberDao.GetModels(" username=@0 ", member.UserName).FirstOrDefault();

                if (sm == null)
                {
                    res.ErrMsg = "您输入登录名有误！";
                }
                else if (sm.Enabled == 0)
                {
                    res.ErrMsg = "您的用户已被禁用！";
                }
                else if (!sm.Pwd.Equals(member.Pwd))
                {
                    res.ErrMsg = "您输入的密码有误！";
                }
                //如果是答疑老师，则前台不让登录
                else if (sm.MemberType == 2)
                {
                    res.ErrMsg = "该用户不允许前台登录！";
                }
                else
                {
                    res.Result = sm;
                }
            }
            catch (Exception ex)
            {
                res.ErrMsg = "登录出现异常！" + ex.Message;
            }
            return res;
        }


        /// <summary>
        /// 外教登录的提示信息
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public Response<Member> TeacherLogin(Member member)
        {
            var res = new Response<Member>();
            try
            {
                var sm = memberDao.GetModels(" username=@0 ", member.UserName).FirstOrDefault();

                if (sm == null)
                {
                    res.ErrMsg = "Login name is incorrect！";
                }
                else if (sm.Enabled == 0)
                {
                    res.ErrMsg = "Your account has been disabled！";
                }
                else if (!sm.Pwd.Equals(member.Pwd))
                {
                    res.ErrMsg = "Password is incorrect！";
                }
                //此处只能是授课老师登陆
                else if (sm.MemberType != 3)
                {
                    res.ErrMsg = "The user is not allowed to log reception！";
                }
                else
                {
                    res.Result = sm;
                }
            }
            catch (Exception ex)
            {
                res.ErrMsg = "Login abnormal！" + ex.Message;
            }
            return res;
        }

        public Response<Member> Register(Member member)
        {
            var res = new Response<Member>();
            try
            {
                memberDao.Insert(member, "UserName", "Pwd", "Mobile", "MemberType");
                res.Result = memberDao.GetModels(" UserName=@0", member.UserName).FirstOrDefault();
            }
            catch (Exception ex)
            {
                res.ErrMsg = "注册出现异常！" + ex.Message;
            }
            return res;
        }

        /// <summary>
        /// 验证码验证
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="uuId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool ExistMemberValid(string mobile, string uuId, string code)
        {
            return memberDao.ExistValidCode(mobile, uuId, code);
        }

        /// <summary>
        /// 是否存在绑定手机号会员
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public bool ExistMember(string mobile)
        {
            return memberDao.GetModels(" username=@0", mobile).Count > 0;
        }
        #endregion

        #region 智能约课
        /// <summary>
        /// 获取上课老师信息
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public Response<List<TeamTeature>> GetClassTeacher(int classId)
        {
            var res = new Response<List<TeamTeature>>();
            try
            {
                res.Result = new TeacherDao().GetClassTeacher(classId);
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取上课老师信息失败！" + ex.Message;
            }
            return res;

        }

        #endregion

        #region 我的课表
        /// <summary>
        /// 直播课表信息
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public Response<List<MemberSchedule>> GetSchedule(int memberId, int month, int memberType)
        {
            var res = new Response<List<MemberSchedule>>();
            try
            {
                //0:学员 1:老师
                res.Result = scheduleDao.GetSchedule(memberId, month, memberType == 1 ? 0 : 1);
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取直播课表信息失败！" + ex.Message;
            }
            return res;
        }
        #endregion

        #region 我的订单
        public Response<List<MyOrder>> GetOrders(int memberId)
        {
            var res = new Response<List<MyOrder>>();
            try
            {
                res.Result = orderDao.GetOrders(memberId, "");
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取我的订单信息失败！" + ex.Message;
            }
            return res;
        }

        public Response<bool> CancelOrder(string orderNo, int memberId)
        {
            var res = new Response<bool>();
            try
            {
                orderDao.Update(new Orders { MemberId = memberId, OrderNo = orderNo, Enabled = -1 }, "OrderNo,MemberId".Split(','), "Enabled");
            }
            catch (Exception ex)
            {
                res.ErrMsg = "取消订单失败！" + ex.Message;
            }
            return res;
        }

        #endregion

        #region 我的评价
        public Response<List<MyEvaluate>> GetClassComment(int id, int memberType, int type)
        {
            var res = new Response<List<MyEvaluate>>();
            try
            {
                if (memberType == 1)
                {
                    if (type == 0)
                    {
                        res.Result = classCommentDao.GetStudentEvaluates(id);
                    }
                    else
                    {
                        res.Result = classCommentDao.GetTeacherEvaluates(id);
                    }
                }
                else
                {
                    if (type == 0)
                    {
                        res.Result = classCommentDao.GetStudentToTeacherEvaluates(id);
                    }
                    else
                    {
                        res.Result = classCommentDao.GetTeacherToStudentEvaluates(id);
                    }
                }
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取我的评价失败！" + ex.Message;
            }
            return res;
        }
        #endregion

        #region 我的提问

        public Response<List<Ask>> GetQuestion(int id)
        {
            var res = new Response<List<Ask>>();
            try
            {
                res.Result = askDao.GetAsks(id);
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取我的提问信息失败！" + ex.Message;
            }
            return res;
        }

        public Response<bool> RaiseQuestion(int id, string content)
        {
            var res = new Response<bool>();
            try
            {
                askDao.Insert(new Ask
                {
                    MemberId = id,
                    Content = content
                }, "MemberId", "Content");
            }
            catch (Exception ex)
            {
                res.ErrMsg = "提问失败！";
                DbHelperSQL.WriteLog("提问失败！", ex);
            }
            return res;
        }

        public Response<List<Answer>> GetQuestionAnswer(int id)
        {
            var res = new Response<List<Answer>>();
            try
            {
                res.Result = answerDao.GetAnswersByAsk(id);
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取我的问题答案信息失败！" + ex.Message;
            }
            return res;
        }

        public Response<bool> SetQuestionAnswer(int answerId)
        {
            var res = new Response<bool>();
            try
            {
                answerDao.Update(new Answer() { AnswerId = answerId, IsAccept = 1 }, "AnswerId".Split(','), "IsAccept");
            }
            catch (Exception ex)
            {
                res.ErrMsg = "采纳回答失败！" + ex.Message;
            }
            return res;
        }

        #endregion


        #region 我的答疑

        public Response<List<Answer>> GetAnswer(int id)
        {
            var res = new Response<List<Answer>>();
            try
            {
                res.Result = answerDao.GetAnswers(id);
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取我的答疑信息失败！" + ex.Message;
            }
            return res;
        }
        #endregion
    }
}
