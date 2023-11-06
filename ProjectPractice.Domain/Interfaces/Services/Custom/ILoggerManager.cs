using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Domain.Interfaces.Services.Custom
{
    public interface ILoggerManager
    {
        /// <summary>
        /// Log when debug.
        /// </summary>
        /// <param name="message">The message or info to log.</param>
        public void LogDebug(string message);

        /// <summary>
        /// Log when occurs a error.
        /// </summary>
        /// <param name="message">The message or info to log.</param>
        public void LogError(string message);

        /// <summary>
        /// Information log..
        /// </summary>
        /// <param name="message">The message or info to log.</param>
        public void LogInfo(string message);

        /// <summary>
        /// Warning log.
        /// </summary>
        /// <param name="message">The message or info to log.</param>
        public void LogWarning(string message);
    }
}
