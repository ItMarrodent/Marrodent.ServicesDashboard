using Marrodent.ServicesDashboard.Controllers;
using Marrodent.ServicesDashboard.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<IConfigurationController, ConfigurationController>();
builder.Services.AddSingleton<iIISControler, IISControler>();

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