using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AdventureLoggerBackend.Controllers;
using AdventureLoggerBackend.Data;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

if (builder.Environment.IsProduction())
{
    var DBpass = Environment.GetEnvironmentVariable("SQL_ROOT_PW");
    var port = Environment.GetEnvironmentVariable("PORT");
    if (!String.IsNullOrEmpty(port))
        builder.WebHost.UseUrls($"http://*:{port}");

    var ConnBuilder = new MySqlConnectionStringBuilder();
    ConnBuilder.Server = "10.56.144.3";
    ConnBuilder.Database = "adventure_logger";
    ConnBuilder.UserID = "root";
    ConnBuilder.Password = DBpass;
    ConnBuilder.Pooling = true;
    builder.Services.AddDbContext<AdventureLoggerBackendContext>(options =>
        options.UseMySQL(ConnBuilder.GetConnectionString(true)));
}
else if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AdventureLoggerBackendContext>(options =>
        options.UseMySQL(builder.Configuration.GetConnectionString("AdventureLoggerBackendContext") ?? throw new InvalidOperationException("Connection string 'AdventureLoggerBackendContext' not found.")));
}

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers().AddNewtonsoftJson();

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
