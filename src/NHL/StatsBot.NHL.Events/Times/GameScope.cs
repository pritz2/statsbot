using System;
using StatsBot.Metadata;

namespace StatsBot.NHL.Events.Times
{
    public class GameScope : ITimeScope
    {
        private readonly int gameNumber, seasonYear;

        public GameScope(int gameNumber, int seasonYear)
        {
            this.gameNumber = gameNumber;
            this.seasonYear = seasonYear;
        }

        public bool CanExtendScope() => true;

        public ITimeScope GetExtendedScope() => new SeasonScope(seasonYear);

        public override string ToString()
        {
            return $"Game {this.gameNumber} during season year {this.seasonYear}";
        }
    }
}
