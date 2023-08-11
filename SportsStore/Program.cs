using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
using SportsStore;

internal class Program
{
    private static void Main(string[] args)
    {
        /*var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        app.Run();*/

        BuildWebHost(args).Run();
    }
    public static IWebHost BuildWebHost(string[] args) => 
        WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().UseDefaultServiceProvider(options => options.ValidateScopes = false).Build();
}