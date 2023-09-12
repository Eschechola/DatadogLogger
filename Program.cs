using Datadog.Trace.Configuration;
using Datadog.Trace;
using Microsoft.Extensions.Logging;

namespace Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("Logger.Program", LogLevel.Debug)
                    .AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<Program>();
            

            while (true){
                Thread.Sleep(2000);
                logger.LogInformation("Info Log");
                logger.LogWarning("Warning Log");
                logger.LogError("Error Log");
                logger.LogCritical("Critical Log");
            }
        }
    }
}