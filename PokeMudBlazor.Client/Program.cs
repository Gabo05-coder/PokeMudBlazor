using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PokeMudBlazor.Client.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Registra el servicio de Pokémon
builder.Services.AddScoped<PokemonApiService>();  // Registro del servicio

// Agrega MudBlazor
builder.Services.AddMudServices();

await builder.Build().RunAsync();