using System;
using System.Web.Mvc;
using Service;
using mvcweb.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mvcweb.Controllers
{
    using Model;
    public class GenseeController : BaseController
    {
        GenSeeService service = new GenSeeService();
        public ActionResult Gensee(int CplId, int CourseType)
        {
            var url = "";
            try
            {
                ViewBag.Path = GetBaseVirtualPath;
                ViewBag.WebCastId = "";
                var user = Common.GetCurrentUser(HttpContext);
                var res = service.GetGenSeeDirectByCpl(CplId, CourseType, user);
                //DataBase.DbHelperSQL.WriteLog("获取展示互动是否为空:ret=" + res == null ? "是" : "否", new Exception());
                if (res != null)
                {
                
                    url = string.Format("{3}?token={0}&nickName={1}&uid={2}", res.Token, System.Web.HttpUtility.UrlEncode(user.Name, System.Text.Encoding.UTF8), user.Id + 1000000000, res.Url);
                    //DataBase.DbHelperSQL.WriteLog("展示互动地址为:url=" + url, new Exception());
                }
                else
                {
                    //DataBase.DbHelperSQL.WriteLog("直播未生成", new Exception());
                    ViewBag.Message = "直播未生成！";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            if (!string.IsNullOrEmpty(url))
            {
                ViewBag.Url = url;
                Response.Redirect(url);
            }
            return View();
        }

        public ActionResult ValidGensee(int CplId, int CourseType)
        {
            var res = new Response<bool>();
            try
            {
                if (service.GetGenSeeDirectByCpl(CplId, CourseType, Common.GetCurrentUser(HttpContext), true) == null)
                {
                    res.ErrMsg = "直播未生成!";
                }
            }
            catch (Exception ex)
            {
                res.ErrMsg = ex.Message;
            }
            return Json(res);
        }

        public void Notify(string ClassNo, string Operator, string Action, string Affected, string totalusernum)
        {
            DataBase.DbHelperSQL.WriteLog("ClassNo=" + ClassNo + "&Operator=" + Operator + "&Action=" + Action + "&Affected=" + Affected + "&totalusernum=" + totalusernum, new Exception());
            switch (Action)
            {
                case "101":

                    break;
            }
        }

        public ActionResult AssignGenSee(int CplId, int CourseType)
        {
            var url = "";
            if (CourseType == 0)
            {
                loger.Trace("播放视频传递参数为:CplId=" + CplId + "&CourseType=" + CourseType);
                //DataBase.DbHelperSQL.WriteLog("CourseType 为0，开始查询新的地址", new Exception());
                var js = Common.GetDistanceInfo(Common.VideoUrl, "{\"CourseType\":0,\"CplId\":" + CplId + "}");
                JObject jr = JsonConvert.DeserializeObject(js) as JObject;
             //   DataBase.DbHelperSQL.WriteLog("播放视频相关参数：js="+js, new Exception());
                loger.Trace("播放视频相关参数：js=" + js);
                url = string.Format("{0}?nickName={1}&token={2}", jr["Data"]["Url"].ToString(), jr["Data"]["Id"].ToString(), jr["Data"]["PASSWORD"].ToString());
                //url = string.Format("{0}?nickName={1}&token={2}", jr["Data"][0]["Url"].ToString(), jr["Data"][0]["Id"].ToString(), jr["Data"][0]["PASSWORD"].ToString());
            }
            else
            {
                url = service.GetUrl(CplId);
            }
            loger.Trace("最终获取的播放视频相关参数：url=" + url);
            return Content(url);
        }
    }
}
