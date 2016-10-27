using Aop.Api.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class BaseService
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
        }
        #endregion
    }
}
