using System;
using Newtonsoft.Json;

namespace StatsBot.NHL.ApiClient.Contracts
{
    public class PlayerStats
    {
        [JsonProperty("goals")]
        public int Goals;

        [JsonProperty("assists")]
        public int Assists;
    }
}
