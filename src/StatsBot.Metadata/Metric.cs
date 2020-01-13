using System;
namespace StatsBot.Metadata
{
    public class Metric
    {
        public Metric(Statistic statistic)
        {
            this.Statistic = statistic;
        }

        public Statistic Statistic { get; }
    }
}
