using System;
using StatsBot.Metadata;

namespace StatsBot.NHL.Events.Statistics
{
    public class Goal : IStatistic
    {
        public Goal()
        {
        }

        public string Name => nameof(Goal);

        public int Value => throw new NotImplementedException();

        public override string ToString()
        {
            return this.Name;
        }
    }
}
