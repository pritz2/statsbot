using System.Collections.Generic;
using System.Threading.Tasks;
using StatsBot.NHL.ApiClient.Contracts;

namespace StatsBot.NHL.ApiClient
{
    public interface INHLClient
    {
        Task<PlayerStats> GetSeasonStatsAsync(int playerId, string season);

        Task<IEnumerable<Split>> GetAllGameStatsAsync(int playerId, string season);
    }
}
