using MudBlazor.Services;
using PokeMudBlazor.Client.Services;
using PokeMudBlazor.Components;
using PokeMudBlazor.Service;

var builder = WebApplication.CreateBuilder(args);


// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddScoped<PokemonApiService>();  // Registro del servicio
builder.Services.AddSingleton<PokemonService>(); //importar servicio
builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowBlazorClient"); // Usa la política de CORS

app.UseRouting();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(PokeMudBlazor.Client._Imports).Assembly);

app.MapControllers();

app.UseRouting(); 

app.UseAuthorization();

app.Run();




