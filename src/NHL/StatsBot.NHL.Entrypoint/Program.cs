using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StatsBot.CoreInterfaces;
using StatsBot.EventListener;

namespace StatsBot.NHL.Entrypoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<ILogger, ConsoleLogger>();
                    services.AddSingleton<IEventProvider, NHLEventProvider>();
                    services.AddHostedService<EventListenerService>();
                });
    }
}
