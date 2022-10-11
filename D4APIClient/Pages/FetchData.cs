using D4APIClient.Dtos;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace D4APIClient.Pages
{
    public partial class FetchData
    {
        [Inject]
        private HttpClient Http { get; set; }
        private LaunchDto[]? launches;

        protected override async Task OnInitializedAsync()
        {
            launches = await Http.GetFromJsonAsync<LaunchDto[]>("/rest/launches");
        }
    }
}