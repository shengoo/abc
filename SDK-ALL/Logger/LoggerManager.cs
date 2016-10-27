using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aop.Api.Logger
{
    public class LoggerManager
    {
        private static readonly object syncObject = new object();

        private static Dictionary<string, ILogger> dics = new Dictionary<string, ILogger>();
        public static ILogger GetLogger(string loggerName)
        {
            if (!dics.ContainsKey(loggerName))
            {
                try
                {
                    dics[loggerName] = new Logger4Net(loggerName);
                }
                catch (Exception ex)
                {

                }
            }
            return dics[loggerName];
        }
    }
}
