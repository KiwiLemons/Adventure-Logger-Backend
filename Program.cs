using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AdventureLoggerBackend.Controllers;
using AdventureLoggerBackend.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AdventureLoggerBackendContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("AdventureLoggerBackendContext") ?? throw new InvalidOperationException("Connection string 'AdventureLoggerBackendContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

if (builder.Environment.IsProduction())
{
    var port = Environment.GetEnvironmentVariable("PORT");
    if (!String.IsNullOrEmpty(port))
        builder.WebHost.UseUrls($"http://*:{port}");
}

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();

}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
