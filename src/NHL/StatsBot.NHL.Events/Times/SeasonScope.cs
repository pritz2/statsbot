using System;
using StatsBot.Metadata;

namespace StatsBot.NHL.Events.Times
{
    public class SeasonScope : ITimeScope
    {
        private readonly int seasonYear;

        public SeasonScope(int seasonYear)
        {
            this.seasonYear = seasonYear;
        }

        public bool CanExtendScope() => true;

        public ITimeScope GetExtendedScope() => new ForeverTimeScope();

        public override string ToString()
        {
            return $"Season year {this.seasonYear}";
        }
    }
}
