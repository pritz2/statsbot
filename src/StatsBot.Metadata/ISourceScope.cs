using System;
namespace StatsBot.Metadata
{
    public interface ISourceScope
    {
        public bool CanExtendScope();

        public ISourceScope GetExtendedScope();
    }
}
