using System.Net;
using Marrodent.ServicesDashboard.Controllers;
using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IWebServiceController, IISController>();
builder.Services.AddSingleton<IServiceController, WindowsServicesController>();
builder.Services.AddSingleton<IConfigurationController, ConfigurationController>();
builder.Services.AddRazorPages();
builder.Services.AddOptions();
builder.Services.Configure<IISConfig>(builder.Configuration.GetSection("IIS_config"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseStaticFiles(); 
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();