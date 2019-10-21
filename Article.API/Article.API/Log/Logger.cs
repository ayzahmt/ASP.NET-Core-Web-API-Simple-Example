using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Article.API
{
    public class Logger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = string.Format("{0}: {1} - {2}", logLevel.ToString(), eventId.Name, formatter(state, exception));
            WriteToFile(message);
        }

        void WriteToFile(string message)
        {
            var path = Path.GetDirectoryName(Environment.CurrentDirectory);
            var fullPath = path + "\\Log.txt";
            using (var sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(message);
                sw.Close();
            }
        }
    }
}
