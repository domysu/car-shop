using AutomobiliuPardavimoPrograma.Components;
using AutomobiliuPardavimoPrograma.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Blazorise;
using Blazorise.Tailwind;
using Blazorise.Icons.FontAwesome;
using Npgsql;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/accessdenied";
        options.Cookie.MaxAge = TimeSpan.FromHours(1);
    });

var env = builder.Environment.EnvironmentName;

if (env == "Development")
{
    // Local dev: read from appsettings.json
    var cs = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContextFactory<AppDbContext>(opts =>
        opts.UseNpgsql(cs));
}
else
{
    // In production on Fly
    
    var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL")
                      ?? throw new InvalidOperationException("DATABASE_URL is not set");

    var uri = new Uri(databaseUrl);
    var userInfo = uri.UserInfo.Split(':', 2);
    var npgsqlBuilder = new NpgsqlConnectionStringBuilder
    {
        Host = uri.Host,
        Port = (int)uri.Port,
        Username = userInfo[0],
        Password = userInfo[1],
        Database = uri.AbsolutePath.TrimStart('/'),
        SslMode = SslMode.Disable,
        TrustServerCertificate = true,
        Pooling = true,
        MinPoolSize = 1,    // <— use MinPoolSize
        MaxPoolSize = 20    // <— use MaxPoolSize
    };
var finalCs = npgsqlBuilder.ConnectionString;

    builder.Services.AddDbContextFactory<AppDbContext>(opts =>
        opts.UseNpgsql(npgsqlBuilder.ConnectionString));
}




builder.Services
    .AddBlazorise()
    .AddTailwindProviders()
    .AddFontAwesomeIcons();
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserCarLikesService>();



var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
  var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
  ctx.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorComponents<App>().AddInteractiveServerRenderMode();


app.Run();
