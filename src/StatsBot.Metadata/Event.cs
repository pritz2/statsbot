using System;
namespace StatsBot.Metadata
{
    public class Event
    {
        public Event(Statistic statistic)
        {
            this.Statistic = statistic;
        }

        public Statistic Statistic { get; }
    }
}
