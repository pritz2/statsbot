using System;
namespace StatsBot.Metadata
{
    public class ForeverTimeScope : ITimeScope
    {
        public bool CanExtendScope() => false;

        public ITimeScope GetExtendedScope() => throw new NotImplementedException();

        public override string ToString()
        {
            return $"ForeverTime";
        }
    }
}
