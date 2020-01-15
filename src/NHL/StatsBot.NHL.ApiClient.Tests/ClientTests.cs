using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using StatsBot.CoreInterfaces;

namespace StatsBot.NHL.ApiClient.Tests
{
    public class ClientTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestGetSeasonStats()
        {
            var client = new NHLWebClient(new ConsoleLogger());
            var patrickKaneStats = await client.GetSeasonStatsAsync(8474141, "20182019");
            Assert.AreEqual(44, patrickKaneStats.Goals);
            Assert.AreEqual(66, patrickKaneStats.Assists);
        }

        [Test]
        public async Task TestGetGameStats()
        {
            var client = new NHLWebClient(new ConsoleLogger());
            var allPatrickKaneGameStats = await client.GetAllGameStatsAsync(8474141, "20182019");
            Assert.AreEqual(81, allPatrickKaneGameStats.Count());
            var march23rdStats = allPatrickKaneGameStats.FirstOrDefault(g => g.Date == new DateTime(2019, 3, 23));
            Assert.NotNull(march23rdStats);
            Assert.AreEqual(0, march23rdStats.PlayerStats.Goals);
            Assert.AreEqual(1, march23rdStats.PlayerStats.Assists);
        }
    }
}