using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace ASPBookProject.Logging
{
    public class CustomFileLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly StreamWriter _logFileWriter;

        public CustomFileLogger(string categoryName, StreamWriter logFileWriter)
        {
            _categoryName = categoryName;
            _logFileWriter = logFileWriter;
        }

        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Information;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;

            var message = formatter(state, exception);
            _logFileWriter.WriteLine($"[{DateTime.Now:HH:mm:ss}] [{logLevel}] [{_categoryName}] {message}");
            _logFileWriter.Flush();
        }
    }

    public class CustomFileLoggerProvider : ILoggerProvider
    {
        private readonly StreamWriter _logFileWriter;

        public CustomFileLoggerProvider(StreamWriter logFileWriter)
        {
            _logFileWriter = logFileWriter ?? throw new ArgumentNullException(nameof(logFileWriter));
        }

        public ILogger CreateLogger(string categoryName) => new CustomFileLogger(categoryName, _logFileWriter);

        public void Dispose() => _logFileWriter.Dispose();
    }
}
