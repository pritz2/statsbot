using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using StatsBot.CoreInterfaces;
using StatsBot.Metadata;

namespace StatsBot.NHL.Entrypoint
{
    public class NHLEventProvider : IEventProvider
    {
        private readonly ILogger<NHLEventProvider> logger;

        public NHLEventProvider(ILogger<NHLEventProvider> logger)
        {
            this.logger = logger;
        }

        public IEnumerable<Event> GetEvents()
        {
            this.logger.LogInformation("Received call for new events");
            return new List<Event>();
        }
    }
}
