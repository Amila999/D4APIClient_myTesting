using D4APIClient;
using D4APIClient.DataServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

Console.WriteLine("Blazore API Client has started...");
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["api_base_url"]) });

builder.Services.AddHttpClient<ISpaceXDataService, GraphQLSpaceXDataService>
    (spds => spds.BaseAddress = new Uri(builder.Configuration["api_base_url"]));

await builder.Build().RunAsync();