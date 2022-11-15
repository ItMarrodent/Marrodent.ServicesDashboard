using Marrodent.ServicesDashboard.Controllers;
using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IServiceController, IISController>();
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

app.UseHttpsRedirection();
app.UseStaticFiles(); 
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();