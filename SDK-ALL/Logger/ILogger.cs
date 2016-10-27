using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aop.Api.Logger
{
    public interface ILogger
    {
        String LoggerName { get; }
        void Trace(string message);
        void Warn(string message);
        void Error(string message);
        void DBG(string message);
    }
}
