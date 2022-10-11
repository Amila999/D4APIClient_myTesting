using D4APIClient.Dtos;
using System.Net.Http.Json;

namespace D4APIClient.DataServices
{
    public class RESTSpaceXDataService : ISpaceXDataService
    {
        private readonly HttpClient _httpclient;

        public RESTSpaceXDataService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }
        public async Task<LaunchDto[]> GetAllLaunches()
        {
            return await _httpclient.GetFromJsonAsync<LaunchDto[]>("/rest/launches");
        }
    }
}
