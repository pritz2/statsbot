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
        public async Task Test1()
        {
            var client = new NHLWebClient(new ConsoleLogger());
            var patrickKaneStats = await client.GetStatsAsync(8474141, "20182019");
            Assert.AreEqual(44, patrickKaneStats.Goals);
            Assert.AreEqual(66, patrickKaneStats.Assists);
        }
    }
}