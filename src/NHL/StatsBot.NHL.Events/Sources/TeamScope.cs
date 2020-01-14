using System;
using StatsBot.Metadata;

namespace StatsBot.NHL.Events.Sources
{
    public class TeamScope : ISourceScope
    {
        private readonly string teamName;

        public TeamScope(string teamName)
        {
            this.teamName = teamName;
        }

        public bool CanExtendScope() => true;

        public ISourceScope GetExtendedScope() => new LeagueScope();

        public override string ToString()
        {
            return $"Team {this.teamName}";
        }
    }
}
