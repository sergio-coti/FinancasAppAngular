using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UsuariosApp.WEB;
using UsuariosApp.WEB.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//configuração para habilitar a biblioteca HttpClient
builder.Services.AddScoped(sp => new HttpClient 
    { BaseAddress = new Uri("http://localhost:5170/api/usuarios/") });

//habilitar a biblioteca Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();

//injeção de dependência para a classe AuthService
builder.Services.AddTransient<AuthService>();

await builder.Build().RunAsync();
