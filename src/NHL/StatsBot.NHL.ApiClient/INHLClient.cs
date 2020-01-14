using System.Threading.Tasks;
using StatsBot.NHL.ApiClient.Contracts;

namespace StatsBot.NHL.ApiClient
{
    public interface INHLClient
    {
        public Task<PlayerStats> GetStatsAsync(int playerId, string season);
    }
}
