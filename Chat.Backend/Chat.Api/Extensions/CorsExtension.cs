using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Api.Extensions
{
    public static class CorsExtension
    {
        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            var corsOrigins = configuration.GetValue<string>("Cors:Origins");
            services.AddCors(options =>
            {
                options.AddPolicy("ClientPermission", policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        //.AllowAnyOrigin()//todo:change to WithOrigins 
                        .WithOrigins(corsOrigins)
                        .AllowCredentials();
                });
            });
          
        }
    }
}
