using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ToolsApp.Core.Interfaces.Data;
using ToolsApp.Core.Interfaces.Web;
using ToolsApp.Data;
using ToolsApp.Web.Data;
using ToolsApp.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTelerikBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<DataContext>();
builder.Services.AddScoped<IColorsData, ColorsSqlServerData>();
// builder.Services.AddScoped<IColorsData, ColorsInMemoryData>();
builder.Services.AddScoped<ICarsData, CarsSqlServerData>();
// builder.Services.AddScoped<ICarsData, CarsInMemoryData>();

builder.Services.AddScoped<IScreenBlocker, ScreenBlocker>();

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
