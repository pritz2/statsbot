﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StatsBot.NHL.ApiClient.Contracts
{
    public class PlayerStatsResponse
    {
        [JsonProperty("stats")]
        public IEnumerable<SplitsResponses> SplitsResponses;
    }

    public class SplitsResponses
    {
        [JsonProperty("splits")]
        public IEnumerable<Split> Splits;
    }
}