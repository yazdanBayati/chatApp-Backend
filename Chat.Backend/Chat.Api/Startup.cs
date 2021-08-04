using Chat.Api.Extensions;
using Chat.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            bool devEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
            if (devEnv) {
                services.AddSignalR();
                services.AddDbContext<ChatDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ChatDbConnection"));
                });
                services.ConfigureSwagger();
            }
            else
            {
                var signalrConnection = Configuration.GetValue<string>("signalrConnection");
                services.AddSignalR().AddAzureSignalR(signalrConnection);

                services.AddDbContext<ChatDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ChatDbConnectionProd"));
                });
            }


            
            
                  
            services.ConfigureCors(Configuration);
            //services.ConfigureSwagger();
            services.AddAutoMapper(typeof(MapperProfiles));
            services.RegisterChatServices(Configuration);
            services.ConfigureIdentity(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ChatDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("ClientPermission");

            //app.AttachSwagger(GetType());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/hubs/chat");
            });
            //dbContext.Database.Migrate();

        }
    }
}
