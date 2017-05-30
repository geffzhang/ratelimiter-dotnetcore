using StoryTeller;
using System.Threading.Tasks;
using System.Net.Http;

namespace functionaltests.ApiFixtures
{
    public class BasicApiChecksFixture : Fixture
    {
        Task<HttpResponseMessage> _response;
        HttpClient client;

        public void RunningSystem()
        {
            client = new HttpClient();
        }

        public void HealthCheck()
        {
            _response = client.GetAsync("http://localhost:8081/api/ping");
        }

        public void Values()
        {
            _response = client.GetAsync("http://localhost:8081/api/values");
        }

        public async Task ValidStatus()
        {
            var res = await _response;
            res.EnsureSuccessStatusCode();
        }
    }
}