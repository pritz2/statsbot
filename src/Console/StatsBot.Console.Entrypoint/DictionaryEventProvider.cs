using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using StatsBot.CoreInterfaces;
using StatsBot.Metadata;

namespace StatsBot.Console.Entrypoint
{
    public class DictionaryEventProvider : IEventProvider
    {
        private ConcurrentBag<Event> events = new ConcurrentBag<Event>();

        public DictionaryEventProvider(ConcurrentBag<Event> events)
        {
            this.events = events;
        }

        public IEnumerable<Event> GetEvents()
        {
            var eventsToReturn = this.events.ToArray();
            this.events.Clear();
            return eventsToReturn;
        }
    }
}
