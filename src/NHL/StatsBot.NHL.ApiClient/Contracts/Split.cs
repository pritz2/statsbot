using System;
using Newtonsoft.Json;

namespace StatsBot.NHL.ApiClient.Contracts
{
    public class Split
    {
        [JsonProperty("season")]
        public string Season;

        [JsonProperty("stat")]
        public PlayerStats PlayerStats;

        [JsonProperty("date")]
        public DateTime Date;
    }
}
