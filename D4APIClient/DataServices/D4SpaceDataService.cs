using D4APIClient.Dtos;
using System.Text;
using System.Text.Json;

namespace D4APIClient.DataServices
{
    public class D4SpaceDataService:ID4SpaceDataService
    {
        private readonly HttpClient _httpclient;

        public D4SpaceDataService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }
        public async Task<D4SpaceDto[]> GetAllSpaces()
        {
            var queryObject = new
            {
                query = @"{spaces {edges { node { id name points { edges { node { id name}}}}}}}",
                variables = new { }
            };

            var query = new StringContent(
                JsonSerializer.Serialize(queryObject),
                Encoding.UTF8,
                "application/json");

            var response = await _httpclient.PostAsync("graph", query);

            if (response.IsSuccessStatusCode)
            {
                var gqlData = await JsonSerializer.DeserializeAsync<D4SpaceData>
                    (await response.Content.ReadAsStreamAsync());
                return gqlData.Data.D4Spaces;
            }
            return null;
        }
    }
}
