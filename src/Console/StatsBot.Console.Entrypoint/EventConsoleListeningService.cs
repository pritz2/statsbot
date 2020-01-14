using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using StatsBot.Metadata;
using StatsBot.NHL.Events.Sources;
using StatsBot.NHL.Events.Statistics;
using StatsBot.NHL.Events.Times;

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
                this.eventStore.Add(
                    new Event(
                        new Goal(),
                        new PlayerScope("Patrick Kane", "Blackhawks"),
                        new PeriodScope(2, 10, 2020)));
            }

            return Task.CompletedTask;
        }
    }
}
