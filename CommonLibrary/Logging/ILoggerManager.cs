using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Logging
{
    public interface ILoggerManager
    {
        void LogInfo(string message, object details = null);

        void LogWarnning(string message, object details = null);

        void LogDebug(string message, object details = null);

        void LogError(string message, Exception ex, object details = null);

        IDisposable FormContext(string key, string value);

    }
}
