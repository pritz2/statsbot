using System;
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

        public async Task<PlayerStats> GetStatsAsync(int playerId, string season)
        {
            this.logger.LogInformation($"Getting stats for played with ID {playerId} for season {season}");
            var requestPath = $"people/{playerId}/stats?stats=statsSingleSeason&season={season}";
            using var response = await this.httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri(BaseApi, requestPath)));
            if (!response.IsSuccessStatusCode)
            {
                throw new NHLApiException(requestPath, response.StatusCode);
            }

            using var body = await response.Content.ReadAsStreamAsync();
            using var jr = new JsonTextReader(new StreamReader(body));
            var statsResponse = NhlSerializer.Deserialize<PlayerStatsResponse>(jr);
            return statsResponse.SplitsResponses.First().SplitsResponseArray.First().PlayerStats;
        }
    }
}
