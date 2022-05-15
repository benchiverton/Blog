using System;
using System.Net.Http;
using System.Threading.Tasks;
using BenChiverton.Blog.Blogs;
using BenChiverton.Blog.Projects;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace BenChiverton.Blog;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("app");

        Log.Logger = new LoggerConfiguration()
            .WriteTo.BrowserConsole()
            .CreateLogger();

        builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddTransient<IBlogService, BlogService>();
        builder.Services.AddTransient<IProjectService, ProjectService>();

        var host = builder.Build();

        await host.RunAsync();
    }
}
