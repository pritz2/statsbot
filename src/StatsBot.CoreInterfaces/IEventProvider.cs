using System.Collections.Generic;
using StatsBot.Metadata;

namespace StatsBot.CoreInterfaces
{
    public interface IEventProvider
    {
        public IEnumerable<Event> GetEvents();
    }
}
