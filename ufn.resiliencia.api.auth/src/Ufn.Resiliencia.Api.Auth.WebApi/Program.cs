using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Mvc;

using Serilog;

using Ufn.Resiliencia.Api.Auth.WebApi.Api.Config;
using Ufn.Resiliencia.Api.Auth.WebApi.Api.Filters;
using Ufn.Resiliencia.Api.Auth.WebApi.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

AppSettingsHelper.AppSettingsConfigure(builder.Configuration);

SerilogConfig.AddSerilogConfig();
builder.Host.UseSerilog();

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.Sources.Clear();
    var env = hostingContext.HostingEnvironment;

    config.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

    if (args != null)
    {
        config.AddCommandLine(args);
    }
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers(opt => opt.Filters.Add<NotificationFilter>()).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddSwaggerConfig();
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.ListenAnyIP(5001);
});

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddAuthenticationConfig();
builder.Services.RegisterMaps();
builder.Services.AddDependencyInjection();
builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

builder.Services.AddIdentityConfig();

//Add Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
//middleware que injeta informa��es da request no log
app.UseMiddleware<SerilogHttpRequestMiddleware>();
app.UseSerilogRequestLogging();
//middleware que trata as exceções e escreve no log
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.MapControllers();

// Configure the HTTP request pipeline.
if (!app.Environment.IsEnvironment("prd"))
{
    app.UseSwaggerConfig();
}

app.Run();