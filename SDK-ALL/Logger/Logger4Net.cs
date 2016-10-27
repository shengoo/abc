using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aop.Api.Logger
{
    public class Logger4Net : ILogger
    {
        private string _loggerName = "";
        public string LoggerName { get { return _loggerName; } }
        private readonly log4net.ILog loger = null;

        public Logger4Net(string loggerName)
        {
            _loggerName = loggerName;
            loger = log4net.LogManager.GetLogger(_loggerName);
        }


        public void Trace(string message)
        {
            if (loger.IsDebugEnabled)
            {
                loger.Debug(message);
            }
        }
        public void Warn(string message)
        {
            if (loger.IsWarnEnabled)
            {
                loger.Warn(message);
            }
        }
        public void Info(string message)
        {
            if (loger.IsInfoEnabled)
            {
                loger.Info(message);
            }
        }
        public void DBG(string message)
        {
            if (loger.IsDebugEnabled)
            {
                loger.Debug(message);
            }
        }



        public void Error(string message)
        {
            if (loger.IsErrorEnabled)
            {
                loger.Error(message);
            }
        }
    }
}
