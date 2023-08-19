using Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PruebaTecnica_JohanFranco.Client;
using PruebaTecnica_JohanFranco.Client.Helpers;
using PruebaTecnica_JohanFranco.Client.Services;
using PruebaTecnica_JohanFranco.Client.Services.Contact;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IResponseHelper, ResponseHelper>();
builder.Services.AddScoped<IAccessService, AccessService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthService>(
    provider => provider.GetRequiredService<AuthService>()
);
builder.Services.AddScoped<IAuthService, AuthService>(
   provider => provider.GetRequiredService<AuthService>()
    );
builder.Services.AddScoped<IMessage, Message>();
builder.Services.AddScoped<IContactoService, ContactoService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAuthorizationCore();
await builder.Build().RunAsync();
