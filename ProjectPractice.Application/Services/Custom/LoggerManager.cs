using ProjectPractice.Domain.Interfaces.Services.Custom;
using NLog;

namespace ProjectPractice.Application.Services.Custom
{
    public class LoggerManager : ILoggerManager
    {
         private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

         public LoggerManager()
         {
         }

         public void LogDebug(string message)
         {
             _logger.Debug($"{DateTime.Now::dd-MM-yyyy HH:mm:ss}\n{message}");
         }

         public void LogError(string message)
         {
             _logger.Error($"{DateTime.Now::dd-MM-yyyy HH:mm:ss}\n{message}");
         }

         public void LogInfo(string message)
         {
             _logger.Info($"{DateTime.Now::dd-MM-yyyy HH:mm:ss}\n{message}");
         }

         public void LogWarning(string message)
         {
             _logger.Warn($"{DateTime.Now::dd-MM-yyyy HH:mm:ss}\n{message}");
         }
    }
}
