using System;
using Chat.Api.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Chat.Api.Extensions
{
    public static class SwaggerExtension
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            // Add Swagger relates setting
            services.AddSwaggerGen(swagger =>
            {
                swagger.EnableAnnotations();
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Chat API",
                    Version = "v1.0",
                    Description = "API for Chat related modules.",
                });
                swagger.IncludeXmlComments(FileHelper.XmlCommentsFilePath);
            });
        }

        public static IApplicationBuilder AttachSwagger(this IApplicationBuilder app, Type currentType)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chat API");
                c.EnableValidator("https://validator.swagger.io/validator");
                c.IndexStream = () => currentType.Assembly.GetManifestResourceStream("Chat.Api.Swagger.index.html");
            });

            return app;
        }
    }
}
