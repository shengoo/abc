using Aop.Api.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcweb.Controllers
{
    public class BascVirtualController : Controller
    {
        //
        // GET: /BascVirtual/

        //public ActionResult Index()
        //{
        //    return View();
        //}

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
}
