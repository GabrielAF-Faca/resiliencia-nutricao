using Microsoft.OpenApi.Models;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Api.Config;

[ExcludeFromCodeCoverage]
public static class SwaggerConfig
{
    public static void AddSwaggerConfig(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"Authorization header using the Bearer scheme. Enter 'Bearer'[space] and then your token in the text input below. Example: 'Bearer 12345abcdef'",
                Name = "Authorization",
                Scheme = "Bearer",
                In = ParameterLocation.Header
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                  new OpenApiSecurityScheme
                  {
                    Reference = new OpenApiReference
                      {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                      },
                      Scheme = "oauth2",
                      Name = "Bearer",
                      In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });
    } 

    public static void UseSwaggerConfig(this IApplicationBuilder app)
    {
        if (app == null) throw new ArgumentNullException(nameof(app));

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("./v1/swagger.json", "Authentication Api");
        });
    }
}
