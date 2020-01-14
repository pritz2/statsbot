using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StatsBot.CoreInterfaces;
using StatsBot.EventListener;
using StatsBot.Metadata;

namespace StatsBot.Console.Entrypoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var consoleProvidedEvents = new ConcurrentBag<Event>();
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<ILogger, ConsoleLogger>();
                    services.AddSingleton<IEventProvider>((serviceProvider) => new DictionaryEventProvider(consoleProvidedEvents));
                    services.AddHostedService<EventListenerService>();
                    services.AddHostedService<EventConsoleListeningService>((serviceProvider) => new EventConsoleListeningService(consoleProvidedEvents));
                });
        }
    }
}
