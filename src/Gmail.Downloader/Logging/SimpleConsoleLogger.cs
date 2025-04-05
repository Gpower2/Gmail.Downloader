using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Gmail.Downloader.Logging
{
    public class SimpleConsoleLogger : ILogger
    {
        private static object _messageLock = new object();

        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string message = "";
            if (formatter != null)
            {
                message += formatter(state, exception);
            }

            string shortLevel = "";
            ConsoleColor backgroundColor = ConsoleColor.Black;
            ConsoleColor foregroundColor = ConsoleColor.White;

            switch (logLevel)
            {
                case LogLevel.Trace:
                    shortLevel = "TRC";
                    foregroundColor = ConsoleColor.Gray;
                    break;
                case LogLevel.Debug:
                    shortLevel = "DBG";
                    foregroundColor = ConsoleColor.DarkGray;
                    break;
                case LogLevel.Information:
                    shortLevel = "INF";
                    break;
                case LogLevel.Warning:
                    shortLevel = "WRN";
                    foregroundColor = ConsoleColor.Magenta;
                    break;
                case LogLevel.Error:
                    shortLevel = "ERR";
                    foregroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Critical:
                    shortLevel = "CRT";
                    foregroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.None:
                    shortLevel = "---";
                    break;
                default:
                    shortLevel = "INF";
                    break;
            }

            lock (_messageLock)
            {
                Console.BackgroundColor = backgroundColor;
                Console.ForegroundColor = foregroundColor;
                Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}][{shortLevel}] {message?.Trim()}");
                Debug.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}][{shortLevel}] {message?.Trim()}");
                Console.ResetColor();
            }
        }
    }

    public class SimpleConsoleLogger<T> : SimpleConsoleLogger, ILogger<T>
    {
    }
}
