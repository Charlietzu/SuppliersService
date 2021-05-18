using Elmah.Io.AspNetCore;
using Elmah.Io.AspNetCore.HealthChecks;
using Elmah.Io.Extensions.Logging;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuppliersService.Api.Extensions;
using System;

namespace SuppliersService.Api.Configuration
{
    public static class LoggerConfig
    {
        private const string apiKey = "e80f4badef884d139d55417047c319ab";
        private const string logId = "dd9425b4-e993-4e4e-9a6e-b6d83cd6b200";

        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = apiKey;
                o.LogId = new Guid(logId);
            });

            //In case you want to add additional logging configuration, uncomment the code bellow
            /*
            services.AddLogging(builder =>
            {
                builder.AddElmahIo(o =>
                {
                    o.ApiKey = apiKey;
                    o.LogId = new Guid(logId);
                });

                builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            });
            */
            services.Configure<ElmahIoPublisherOptions>(options =>
            {
                options.ApiKey = apiKey;
                options.LogId = new Guid(logId);
                options.Application = "SuppliersService API";
            });

            services.AddHealthChecks()
                .AddElmahIoPublisher()
                .AddCheck("Products", new SqlServerHealthCheck(config.GetConnectionString("DefaultConnection")))
                .AddSqlServer(config.GetConnectionString("DefaultConnection"), name: "SQLDatabase");

            services.AddHealthChecksUI();

            return services;
        }
        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            const string healthCheckApiPath = "/api/hc";

            app.UseHealthChecks(healthCheckApiPath, new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options => {
                options.UIPath = $"{healthCheckApiPath}-ui";
                options.ApiPath = $"{healthCheckApiPath}-api";
                options.UseRelativeApiPath = false;
                options.UseRelativeResourcesPath = false;
            });

            return app;
        }
    }
}
