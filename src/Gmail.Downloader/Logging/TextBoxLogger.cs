using System;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace Gmail.Downloader.Logging
{
    public class TextBoxLogger : ILogger
    {
        protected readonly TextBox _textBox;

        public TextBoxLogger(TextBox textBox)
        {
            _textBox = textBox ?? throw new ArgumentNullException(nameof(textBox));
        }

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
            switch (logLevel)
            {
                case LogLevel.Trace:
                    shortLevel = "TRC";
                    break;
                case LogLevel.Debug:
                    shortLevel = "DBG";
                    break;
                case LogLevel.Information:
                    shortLevel = "INF";
                    break;
                case LogLevel.Warning:
                    shortLevel = "WRN";
                    break;
                case LogLevel.Error:
                    shortLevel = "ERR";
                    break;
                case LogLevel.Critical:
                    shortLevel = "CRT";
                    break;
                case LogLevel.None:
                    shortLevel = "---";
                    break;
                default:
                    shortLevel = "INF";
                    break;
            }

            _textBox.Invoke(new Action(() => _textBox.AppendText($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}][{shortLevel}] {message?.Trim()}{Environment.NewLine}")));
        }
    }

    public class TextBoxLogger<T> : TextBoxLogger, ILogger<T>
    {
        public TextBoxLogger(TextBox textBox) : base(textBox) { }
    }
}
