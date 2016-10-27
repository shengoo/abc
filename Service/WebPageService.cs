using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Configuration;

namespace Service
{
    using DataBase;
    using Model.ViewModel;
    public class WebPageService
    {
        OpenClassDao dao = new OpenClassDao();

        public List<WebSiteBasicSetting> GetWebSiteBasicSetting()
        {
            return new WebSiteBasicSettingDao().GetClassModels("select * from WebSiteBasicSetting");
        }

        public Response<List<OpenClass>> GetOpenClass(MemberDto member)
        {
            var res = new Response<List<OpenClass>>();
            try
            {
                res.Result = dao.GetOpenClass(member == null ? 0 : member.Id);
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取公开课失败！" + ex.Message;
            }
            return res;
        }

        public Response<List<WebSitePic>> GetPageImages(int siteType, int typeId)
        {
            try
            {
                return new Response<List<WebSitePic>>
                {
                    Result = new WebSitePicDao().GetWebSitePic(siteType, typeId)
                };
            }
            catch (Exception ex)
            {
                DbHelperSQL.WriteLog("获取图片信息失败", ex);
                return new Response<List<WebSitePic>>
                {
                    ErrMsg = "获取图片信息失败!"
                };

            }
        }

        public class Voice
        {
            public string Name { get; set; }

            public string Content { get; set; }

            public string Logo { get; set; }

            public string VideoUrl { set; get; }
        }

        public Response<List<Voice>> GetVoice(string sitetype = "0")
        {
            var res = new Response<List<Voice>>();
            try
            {
                string sqlstring = "", level = "";
                if (sitetype.Equals("0"))//如果是成人版
                {
                    level = ConfigurationManager.AppSettings["AdultLevel"];
                    sqlstring = string.Format("select top 8 cnname name,voice content,logo,HowKnow AS VideoUrl from member where membertype=1 and isvisible=1 AND GradeId IN (SELECT LevelId FROM CourseLevel WHERE ParentId={0} ) order by orderby ASC", level);
                }
                else
                {
                    level = ConfigurationManager.AppSettings["ChildLevel"];
                    sqlstring = string.Format("select top 8 cnname name,voice content,logo,HowKnow AS VideoUrl from member where membertype=1 and isvisible=1 and isstart=0 AND GradeId IN (SELECT LevelId FROM CourseLevel WHERE ParentId={0} ) order by orderby ASC", level);
                }
              
                res.Result = DbHelperSQL.ExcuteScaler<Voice>(sqlstring);
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取学员心声失败！" + ex.Message;
            }
            return res;
        }

        /// <summary>
        /// 获取明星学员
        /// </summary>
        /// <returns></returns>
        public Response<List<Voice>> GetStarStudent()
        {
            var res = new Response<List<Voice>>();
            try
            {
                string sqlstring = "",  level = ConfigurationManager.AppSettings["ChildLevel"];
                sqlstring = string.Format("select top 8 cnname name,voice content,logo,HowKnow AS VideoUrl from member where membertype=1 and isstart=1 AND GradeId IN (SELECT LevelId FROM CourseLevel WHERE ParentId={0} ) order by orderby ASC", level);
                res.Result = DbHelperSQL.ExcuteScaler<Voice>(sqlstring);
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取明星学员失败！" + ex.Message;
            }
            return res;
        }

        public Response<bool> HoldOpenClass(int memberId, int classId)
        {
            var res = new Response<bool>();
            try
            {
                if (dao.GetModels(" memberid=@0 and openclassid=@1 ", memberId, classId).Count == 0)
                {
                    if (DataBase.DbHelperSQL.GetSingle("SELECT 1 FROM  OpenClass WHERE openclassid=@0 AND maxstudentnum > (SELECT count(1) FROM OpenClassMember WHERE OpenClassId=@0)", classId) != null)
                    {
                        dao.Insert(new OpenClassMember()
                        {
                            OpenClassId = classId,
                            MemberId = memberId,
                            JoinTime = DateTime.Now
                        }, "OpenClassId", "MemberId", "JoinTime");
                    }
                    else
                    {
                        res.ErrMsg = "课程人数已满！请选择其它课程！";
                    }
                }
                else
                {
                    res.ErrMsg = "您已加入此次课程！不能重复加入！";
                }
            }
            catch (Exception ex)
            {
                res.ErrMsg = "占坐失败！" + ex.Message;
            }
            return res;
        }

        public Response<List<Article>> GetArticle()
        {
            var res = new Response<List<Article>>();
            try
            {
                res.Result = new ArticleDao().GetArticles();
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取每日一句失败！" + ex.Message;
            }
            return res;
        }

        public Article GetArticle(int id)
        {
            return new ArticleDao().GetArticle(id);
        }

        public List<ArtcleViewModel> GetArtListForFooter()
        {
            return new ArticleDao().GetArtcleListForFooter();
        }

    }
}
