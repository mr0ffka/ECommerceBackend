using ECommerce.Application.Contracts.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Logging
{
    public class LoggerAdapter<T> : Application.Contracts.Logging.IAppLogger<T>
    {
        private readonly Microsoft.Extensions.Logging.ILogger<T> _logger;
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogErr(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }

        public void LogInfo(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarn(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
    }
}
