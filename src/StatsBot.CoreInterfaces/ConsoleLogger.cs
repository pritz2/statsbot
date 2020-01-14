using System;
namespace StatsBot.CoreInterfaces
{
    public class ConsoleLogger : ILogger
    {
        public void LogInformation(string message)
        {
            Console.WriteLine(message);
        }
    }
}
