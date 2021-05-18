using Elmah.Io.AspNetCore;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace SuppliersService.Api.Configuration
{
    public static class LoggerConfig
    {
        private const string apiKey = "e80f4badef884d139d55417047c319ab";
        private const string logId = "dd9425b4-e993-4e4e-9a6e-b6d83cd6b200";

        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services)
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

            return services;
        }
        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
