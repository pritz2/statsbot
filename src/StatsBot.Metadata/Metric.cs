using System;
namespace StatsBot.Metadata
{
    public class Metric
    {
        public Metric(
            IStatistic statistic,
            ISourceScope sourceScope,
            ITimeScope timeScope)
        {
            this.Statistic = statistic;
            this.SourceScope = sourceScope;
            this.TimeScope = timeScope;
        }

        public IStatistic Statistic { get; }

        public ISourceScope SourceScope { get; }

        public ITimeScope TimeScope { get; }

        public override string ToString()
        {
            return $"{this.Statistic} happened due to {this.SourceScope} at time {this.TimeScope}";
        }
    }
}
