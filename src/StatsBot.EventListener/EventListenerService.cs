using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using StatsBot.CoreInterfaces;
using StatsBot.Metadata;

namespace StatsBot.EventListener
{
    public class EventListenerService : BackgroundService
    {
        private readonly ILogger logger;

        private readonly IEventProvider eventProvider;

        public EventListenerService(ILogger logger, IEventProvider eventProvider)
        {
            this.logger = logger;
            this.eventProvider = eventProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                this.logger.LogInformation($"{nameof(EventListenerService)} running at: {DateTimeOffset.Now}");
                var newEvents = this.eventProvider.GetEvents();
                this.logger.LogInformation($"Got {newEvents.Count()} events");
                foreach (var newEvent in newEvents)
                {
                    this.logger.LogInformation($"Got event [{newEvent}]");
                    var affectedMetrics = this.GetAffectedMetrics(newEvent);
                    this.logger.LogInformation($"Got {affectedMetrics.Count()} related metrics for this event");
                    foreach (var affectedMetric in affectedMetrics)
                    {
                        this.logger.LogInformation($"Got affected metric [{affectedMetric}]");
                    }
                }

                await Task.Delay(1000, stoppingToken);
            }
        }

        private IEnumerable<Metric> GetAffectedMetrics(Event newEvent)
        {
            var baseMetric = new Metric(newEvent.Statistic, newEvent.SourceScope, newEvent.TimeScope);
            var sourceExtendedMetrics = new List<Metric> { baseMetric };
            var currentMetric = baseMetric;
            while (currentMetric.SourceScope.CanExtendScope())
            {
                var sourceExtendedMetric = new Metric(
                    currentMetric.Statistic,
                    currentMetric.SourceScope.GetExtendedScope(),
                    currentMetric.TimeScope);
                sourceExtendedMetrics.Add(sourceExtendedMetric);
                currentMetric = sourceExtendedMetric;
            }

            var affectedMetrics = new List<Metric>();
            foreach (var sourceExtendedMetric in sourceExtendedMetrics)
            {
                affectedMetrics.Add(sourceExtendedMetric);
                currentMetric = sourceExtendedMetric;
                while (currentMetric.TimeScope.CanExtendScope())
                {
                    var timeExtendedMetric = new Metric(
                        currentMetric.Statistic,
                        currentMetric.SourceScope,
                        currentMetric.TimeScope.GetExtendedScope());
                    affectedMetrics.Add(timeExtendedMetric);
                    currentMetric = timeExtendedMetric;
                }
            }

            return affectedMetrics;
        }
    }
}
