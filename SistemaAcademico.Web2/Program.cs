using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SistemaAcademico.Web2;
using SistemaAcademico.Web2.Services;
using WalletWatch.Web.Services;
using System.Globalization;
using Microsoft.AspNetCore.Components.Authorization;


internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services
            .AddBlazorise(options => { options.Immediate = true; })
            .AddBootstrapProviders()
            .AddFontAwesomeIcons();

        builder.Services.AddScoped<AlunoAPI>();
        builder.Services.AddScoped<MatriculaAPI>();
        builder.Services.AddScoped<CursoAPI>();
        builder.Services.AddScoped<ProfessorAPI>();
        builder.Services.AddScoped<HorarioAPI>();
        builder.Services.AddScoped<NotaAPI>();
        builder.Services.AddScoped<TurmaAPI>();
        builder.Services.AddScoped<DisciplinaAPI>();
        builder.Services.AddScoped<FrequenciaAPI>();
        builder.Services.AddScoped<FinanceiroAPI>();
        builder.Services.AddScoped<RelatorioAPI>();
        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthenticationStateProvider, AuthAPI>();
        builder.Services.AddScoped<AuthAPI>(sp => (AuthAPI)sp.GetRequiredService<AuthenticationStateProvider>());
        builder.Services.AddScoped<CookieHandler>();


        builder.Services.AddMudServices();

        builder.Services.AddHttpClient("API", client =>
        {
            client.BaseAddress = new Uri(builder.Configuration["APIServer:Url"]!);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        }).AddHttpMessageHandler<CookieHandler>();

        await builder.Build().RunAsync();
    }
}   