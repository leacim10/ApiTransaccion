using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Logger
{
    public static class Extension
    {
        private static readonly string LogSectionName = "Logs";

        public static IServiceCollection AddLogger(this IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }
            LoggerOptions options = new LoggerOptions();
            configuration.GetSection(LogSectionName).Bind(options);
            services.AddSingleton<ILogger, Logger>(sp =>
            {
                return new Logger(options.Path_Log_File, options.Level);
            });
            return services;
        }
    }
}
