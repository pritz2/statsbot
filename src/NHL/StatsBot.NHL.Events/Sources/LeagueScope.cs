using System;
using StatsBot.Metadata;

namespace StatsBot.NHL.Events.Sources
{
    public class LeagueScope : ISourceScope
    {
        public bool CanExtendScope() => false;

        public ISourceScope GetExtendedScope() => throw new NotImplementedException();

        public override string ToString()
        {
            return $"Leaguewide";
        }
    }
}
