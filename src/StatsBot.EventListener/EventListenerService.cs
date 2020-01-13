using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StatsBot.CoreInterfaces;

namespace StatsBot.EventListener
{
    public class EventListenerService : BackgroundService
    {
        private readonly ILogger<EventListenerService> logger;

        private readonly IEventProvider eventProvider;

        public EventListenerService(ILogger<EventListenerService> logger, IEventProvider eventProvider)
        {
            this.logger = logger;
            this.eventProvider = eventProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                this.logger.LogInformation($"{nameof(EventListenerService)} running at: {DateTimeOffset.Now}");
                var events = this.eventProvider.GetEvents();
                this.logger.LogInformation($"Got {events.Count()} events");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
