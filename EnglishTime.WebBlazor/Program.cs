using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using EnglishTime.WebBlazor.Pages.User.Shared;
using EnglishTime.WebBlazor.Pages.Tip.Shared;

namespace EnglishTime.WebBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddHttpClient<IUserService, UserServiceApiRest>(sp => sp.BaseAddress = new Uri("https://localhost:5001/"));
            builder.Services.AddHttpClient<ITipService, TipServiceApiRest>(sp => sp.BaseAddress = new Uri("https://localhost:5001/"));

            await builder.Build().RunAsync();
        }
    }
}
