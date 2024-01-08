using Microsoft.Extensions.Logging;

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
