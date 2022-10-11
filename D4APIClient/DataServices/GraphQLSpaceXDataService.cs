using D4APIClient.Dtos;
using System.Text;
using System.Text.Json;

namespace D4APIClient.DataServices
{
    public class GraphQLSpaceXDataService:ISpaceXDataService
    {
        private readonly HttpClient _httpclient;

        public GraphQLSpaceXDataService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }

        public async Task<LaunchDto[]> GetAllLaunches()
        {
            var queryObject = new {
                query = @"{launches{id is_tentative mission_name launch_date_local}}",
                variables = new { }
            };

            var launchQuery = new StringContent(
                JsonSerializer.Serialize(queryObject),
                Encoding.UTF8,
                "application/json");

            var response = await _httpclient.PostAsync("graphql", launchQuery);

            if (response.IsSuccessStatusCode) 
            {
                var gqlData = await JsonSerializer.DeserializeAsync<GqlData>
                    (await response.Content.ReadAsStreamAsync());
                return gqlData.Data.Launches;
            }
            return null;
        }
    }
}
