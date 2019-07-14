using System;
using Quartz.Logging;

namespace Quartz.NET_Demo.Services
{
    public class QuartzLogProvider : ILogProvider
    {
        public Logger GetLogger(string name)
        {
            return (level, func, exception, parameters) =>
            {
                if (level >= LogLevel.Info && func != null)
                {
                    Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] [" + level + "] " + func(), parameters);
                }
                return true;
            };
        }

        public IDisposable OpenMappedContext(string key, string value)
            => default;

        public IDisposable OpenNestedContext(string message)
            => default;
    }
}
