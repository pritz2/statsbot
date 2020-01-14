using System;
using StatsBot.Metadata;

namespace StatsBot.NHL.Events.Times
{
    public class PeriodScope : ITimeScope
    {
        private readonly int periodNumber, gameNumber, seasonYear;

        public PeriodScope(int periodNumber, int gameNumber, int seasonYear)
        {
            this.periodNumber = periodNumber;
            this.gameNumber = gameNumber;
            this.seasonYear = seasonYear;
        }

        public bool CanExtendScope() => true;

        public ITimeScope GetExtendedScope() => new GameScope(this.gameNumber, this.seasonYear);

        public override string ToString()
        {
            return $"Period {this.periodNumber} of game {this.gameNumber} during season year {this.seasonYear}";
        }
    }
}
