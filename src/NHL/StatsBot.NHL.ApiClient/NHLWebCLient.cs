using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StatsBot.CoreInterfaces;
using StatsBot.NHL.ApiClient.Contracts;
using StatsBot.NHL.ApiClient.Exceptions;

namespace StatsBot.NHL.ApiClient
{
    public class NHLWebClient
    {
        private static readonly Uri BaseApi = new Uri("https://statsapi.web.nhl.com/api/v1/");
        private static readonly JsonSerializerSettings NhlSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        private static readonly JsonSerializer NhlSerializer = JsonSerializer.Create(NhlSerializerSettings);

        private readonly HttpClient httpClient = new HttpClient();

        private readonly ILogger logger;

        public NHLWebClient(ILogger logger)
        {
            this.logger = logger;
        }

        public async Task<PlayerStats> GetSeasonStatsAsync(int playerId, string season)
        {
            this.logger.LogInformation($"Getting stats for played with ID {playerId} for season {season}");
            var requestPath = $"people/{playerId}/stats?stats=statsSingleSeason&season={season}";
            var statsResponse = await this.MakeRequestAsync<PlayerStatsResponse>(HttpMethod.Get, requestPath);
            return statsResponse.SplitsResponses.First().Splits.First().PlayerStats;
        }

        public async Task<IEnumerable<Split>> GetAllGameStatsAsync(int playerId, string season)
        {
            this.logger.LogInformation($"Getting all splits for played with ID {playerId} for season {season}");
            var requestPath = $"people/{playerId}/stats?stats=gameLog&season={season}";
            var statsResponse = await this.MakeRequestAsync<PlayerStatsResponse>(HttpMethod.Get, requestPath);
            return statsResponse.SplitsResponses.First().Splits;
        }

        private async Task<T> MakeRequestAsync<T>(HttpMethod httpMethod, string path)
        {
            using var response = await this.httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri(BaseApi, path)));
            if (!response.IsSuccessStatusCode)
            {
                throw new NHLApiException(path, response.StatusCode);
            }

            using var body = await response.Content.ReadAsStreamAsync();
            using var jr = new JsonTextReader(new StreamReader(body));
            return NhlSerializer.Deserialize<T>(jr);
        }
    }
}
