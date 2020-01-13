using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StatsBot.Metadata;

namespace StatsBot.Console.Entrypoint
{
    public class EventConsoleListeningService : BackgroundService
    {
        private readonly ConcurrentBag<Event> eventStore;

        public EventConsoleListeningService(ConcurrentBag<Event> eventStore)
        {
            this.eventStore = eventStore;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                System.Console.ReadLine();
                this.eventStore.Add(new Event(new Statistic()));
            }

            return Task.CompletedTask;
        }
    }
}
