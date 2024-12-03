using System;
using System.Net.Http;
using BenChiverton.Blog;
using BenChiverton.Blog.Blogs;
using BenChiverton.Blog.Icons;
using BenChiverton.Blog.Markdown;
using BenChiverton.Blog.Projects;
using BenChiverton.Blog.Resources;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("app");

Log.Logger = new LoggerConfiguration()
    .WriteTo.BrowserConsole()
    .CreateLogger();

builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddTransient<IMarkdownService, MarkdownService>();
builder.Services.AddTransient<IIconService, IconService>();
builder.Services.AddTransient<IBlogService, BlogService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IResourceService, ResourceService>();

var host = builder.Build();

await host.RunAsync();
