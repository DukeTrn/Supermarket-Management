using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Plugins.DataStore.InMemory;
using WebApp.UseCases;
using WebApp.UseCases.DataStorePluginInterfaces;
using WebApp.UseCases.UseCaseInterfaces;
using WebApp.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Dependency Injection for In-Memory Data
builder.Services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();

// Dependency Injection for Use Cases and Repository
builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
