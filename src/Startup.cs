using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AntDesign.ProLayout;
using Mbill.Admin.Common.Tools;
using Mbill.Admin.Extensions.Startup;
using Mbill.Admin.Services.Impl;

namespace Mbill.Admin;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddAntDesign();
        services.AddScoped(sp => new HttpClient
        {
            BaseAddress = new Uri(sp.GetService<NavigationManager>().BaseUri)
        });

        services.Configure<ProSettings>(Configuration.GetSection("ProSettings"));
        services.Configure<Appsettings>(Configuration.GetSection("Appsettings"));

        // ע���û���Ϣ���Storage����
        services.AddScoped<AccountStorageJsService>();
        services.AddScoped<CommonJsService>();

        // ע��HttpClient
        services.AddCoreHttpClient();

        // ע��Service
        services.AddCoreServices();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        //  app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}
