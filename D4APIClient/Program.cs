using D4APIClient;
using D4APIClient.DataServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

Console.WriteLine("Blazore API Client has started...");
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["api_base_url"]) });

builder.Services.AddHttpClient<ID4SpaceDataService, D4SpaceDataService>
    (d4ds =>
    {
        d4ds.BaseAddress = new Uri(builder.Configuration["api_base_url"]);
        d4ds.DefaultRequestHeaders.Add(builder.Configuration["Header1Name"], builder.Configuration["Header1Value"]);
        d4ds.DefaultRequestHeaders.Add(builder.Configuration["Header2Name"], builder.Configuration["Header2Value"]);
    });

await builder.Build().RunAsync();