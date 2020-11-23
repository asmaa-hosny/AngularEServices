using CommonLibrary.Configuaration;
using CommonLibrary.Logging;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Context;
using System;


namespace EServicesCommon.Logging
{
    public class LoggerManager : ILoggerManager
    {
        ILogger _logger;

        ICoreConfigurations _config;

        public LoggerManager(ICoreConfigurations configuration)
        {
            var configuarationBuilder = new ConfigurationBuilder()
                .AddJsonFile("serilogsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _logger = new LoggerConfiguration().ReadFrom.Configuration(configuarationBuilder).Enrich.FromLogContext().CreateLogger();
            _config = configuration;
        }
        public bool IsEnabled
        {
            get
            {
                return _config.EnableLogging;

            }
        }

        public void LogDebug(string message, object details = null)
        {
            if (IsEnabled)
                _logger.ForContext("Details", details, true).Debug(message);
        }

        public void LogError(string message, Exception ex, object details = null)
        {
            if (IsEnabled && ex !=null)
                _logger.ForContext("Details", details, true).Error(ex, message);
            else
                _logger.ForContext("Details", details, true).Error(message);
        }

        public void LogInfo(string message, object details = null)
        {
            if (IsEnabled)
                _logger.ForContext("Details", details, true).Information(message);
        }

        public void LogWarnning(string message, object details = null)
        {
            if (IsEnabled)
                _logger.ForContext("Details", details, true).Warning(message);
        }

        public IDisposable FormContext(string key, string value)
        {
            return LogContext.PushProperty(key, value);
        }
    }
}
