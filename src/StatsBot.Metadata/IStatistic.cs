using System;
namespace StatsBot.Metadata
{
    public interface IStatistic
    {
        string Name { get; }

        int Value { get; }
    }
}
