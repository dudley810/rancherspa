using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SpaApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<WeatherClient>("Weather.Api", client =>
{
    if (builder.HostEnvironment.BaseAddress.Contains("localhost"))
    {
        client.BaseAddress = new System.Uri("https://localhost:8443/");
    }
    else
    {
        client.BaseAddress = new System.Uri("https://dnapi.kubeodc-test.corp.intranet/");
    }
});

await builder.Build().RunAsync();

public class WeatherClient
{
    public WeatherClient(HttpClient client)
    {
        Client = client;
    }

    public HttpClient Client { get; }
}
