using System;
using StatsBot.Metadata;

namespace StatsBot.NHL.Events.Sources
{
    public class PlayerScope : ISourceScope
    {
        private readonly string playerName;
        private readonly string teamName;

        public PlayerScope(string playerName, string teamName)
        {
            this.playerName = playerName;
            this.teamName = teamName;
        }

        public bool CanExtendScope() => true;

        public ISourceScope GetExtendedScope() => new TeamScope(this.teamName);

        public override string ToString()
        {
            return $"Player {this.playerName} on team {this.teamName}";
        }
    }
}
