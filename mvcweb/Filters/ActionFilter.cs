using Model;
using System.Web.Mvc;
using System.IO.Compression;
using Aop.Api.Logger;

namespace mvcweb.Filters
{
    [mvcweb.Filters.ActionFilter]
    public class BaseController : Controller
    {

        #region 日志相关
        public static string LoggerName
        {
            get
            {
                return "Web";
            }
        }

        protected ILogger loger = LoggerManager.GetLogger(LoggerName);

        public void LogTrace(string msg)
        {
            loger.Trace(msg);
        }

        public void LogError(string msg)
        {
            loger.Error(msg);
            //LoggerManager.GetLogger(MyLoggerName).Error(msg);
        }
        #endregion

        protected MemberDto member
        {
            get
            {
                return Common.GetCurrentUser(HttpContext);
            }
        }

        protected string GetBaseVirtualPath
        {
            get
            {
                var virtualpath = "";
                try
                {
                    virtualpath = System.Configuration.ConfigurationManager.AppSettings["BaseVirtualPath"].ToString();
                }
                catch
                {
                }
                return virtualpath;
            }
        }
    }

    public class ActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // 验证
            var cookie = context.HttpContext.Request.Cookies.Get("logininfo");
            if (cookie == null)
            {
                if (context.HttpContext.Request.HttpMethod.ToLower() != "get")
                {
                    var result = new JsonResult();
                    result.Data = new Response<bool>()
                    {
                        Result = false,
                        ErrCode = "1002",
                        ErrMsg = "登录过期,请重新登陆"
                    };
                    context.Result = result;
                    return;
                }
                context.Result = new RedirectResult("/home/index");
                return;
            }

            // 压缩
            var acceptEncoding = context.HttpContext.Request.Headers["Accept-Encoding"];
            if (!string.IsNullOrEmpty(acceptEncoding))
            {
                acceptEncoding = acceptEncoding.ToLower();
                var response = context.HttpContext.Response;
                if (acceptEncoding.Contains("gzip"))
                {
                    response.AppendHeader("Content-encoding", "gzip");
                    response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
                }
                else if (acceptEncoding.Contains("deflate"))
                {
                    response.AppendHeader("Content-encoding", "deflate");
                    response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
                }
            }
        }
    }
}