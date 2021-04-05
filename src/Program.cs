using AntDesign.Pro.Layout;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using mbill_blazor_admin.Common.Tools;
using mbill_blazor_admin.Extensions.Startup;
using mbill_blazor_admin.Services.Impl;

namespace mbill_blazor_admin
{
    public partial class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            
            // ע������
            builder.Services.Configure<Appsettings>(builder.Configuration.GetSection("Appsettings"));
            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));

            Utils.ThemeColors.Add("#be6868", "mbillcolor");
            // ע���û���Ϣ���Storage����
            builder.Services.AddSingleton(typeof(AccountStorageService));
            // ע��HttpClient
            builder.AddCoreHttpClient();
            // ע��Service
            builder.Services.AddCoreServices();
            builder.Services.AddAntDesign();


            await builder.Build().RunAsync();
        }
    }
}