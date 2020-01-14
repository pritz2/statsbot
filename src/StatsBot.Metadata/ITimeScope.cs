using System;
namespace StatsBot.Metadata
{
    public interface ITimeScope
    {
        public bool CanExtendScope();

        public ITimeScope GetExtendedScope();
    }
}
