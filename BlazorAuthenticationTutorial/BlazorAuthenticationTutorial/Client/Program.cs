// https://www.youtube.com/watch?v=Yh16E2u2pio

global using Microsoft.AspNetCore.Components.Authorization;
using BlazorAuthenticationTutorial.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStoreProvider>();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
