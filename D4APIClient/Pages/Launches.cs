using D4APIClient.DataServices;
using D4APIClient.Dtos;
using Microsoft.AspNetCore.Components;

namespace D4APIClient.Pages
{
    public partial class Launches
    {
        [Inject]
        ISpaceXDataService SpaceXDataService { get; set; }
        private LaunchDto[] launches;
        protected override async Task OnInitializedAsync()
        {
            launches = await SpaceXDataService.GetAllLaunches();
        }
    }
}
