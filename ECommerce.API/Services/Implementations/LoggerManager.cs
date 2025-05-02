using NLog;
using ILogger = NLog.ILogger;
using ECommerce.API.Services.Interfaces;
namespace ECommerce.API.Services.Implementations
{
    public class LoggerManager : ILoggerService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message) => logger.Debug(message);
        public void LogError(string message) => logger.Error(message);
        public void LogInformation(string message) => logger.Info(message);
        public void LogWarning(string message) => logger.Warn(message);
    }
}

