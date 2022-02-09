using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Logging
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly FileLogger _logger;

		public FileLoggerProvider(string config)
		{
            _logger = new FileLogger(config);
		}

		public ILogger CreateLogger(string categoryName)
        {
            return _logger;
        }

        public void Dispose()
        {
        }
    }
    public class FileLogger : ILogger
	{
        private string _fileName;
        private static readonly Object obj = new Object();
		public string FilePath { get; set; }

		public FileLogger(string config)
        {

            FilePath = String.IsNullOrEmpty(config) ? "C:/temp/log/": config;
            _fileName = string.Format("logFil_{0}.log", DateTime.Today.ToString("yyyyMMdd"));
            lock (obj)
            {
                File.AppendAllText(FilePath + _fileName, "Start logging \n");
            }
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            _fileName = string.Format("logFil_{0}.log", DateTime.Today.ToString("yyyyMMdd"));
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Information:
                    return false;
                case LogLevel.Trace:
                case LogLevel.Debug:
                case LogLevel.Warning:
                case LogLevel.Error:
                case LogLevel.Critical:
                case LogLevel.None:
                    return true;
            }
            return false;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;

            string fileToWrite = FilePath + _fileName;
            lock (obj)
            {
                string message = string.Format("Level:{0} message: {1} event:{2} \n", logLevel.ToString(), state.ToString(), eventId.ToString());
                File.AppendAllText(fileToWrite, message);
            }
        }
    }
}
