using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VibrantCastPlatform.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure HttpClient for unauthenticated requests
builder.Services.AddHttpClient("HttpPublic", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
})
.ConfigurePrimaryHttpMessageHandler(() =>
{
    return new HttpClientHandler
    {
        UseDefaultCredentials = true,
        AllowAutoRedirect = false
    };
});

// Configure HttpClient for authenticated requests
builder.Services.AddHttpClient("Http", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
})
.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Unauth
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("HttpPublic"));
// Auth
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Http"));

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
