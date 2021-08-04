using Chat.Core.Domains;
using Chat.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Chat.ApplicationService.Services.Group;
using Chat.ApplicationService.Services.Message;
using Chat.ApplicationService.Services.User;
using Chat.ApplicationService.Services.UserGroup;
using Microsoft.Extensions.Configuration;
using Chat.ApplicationService.Services.Auth;

namespace Chat.Api.Extensions
{
    public static class DependencyExtension
    {
        public static void RegisterChatServices(this IServiceCollection services, IConfiguration configuration)
        {
            //repostitories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IUserGroupRepositroy, UserGroupRepository>();

            //services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IUserGroupSevice, UserGroupService>();

            services.AddSingleton<IAuthService>(
                new AuthService(
                    configuration.GetValue<string>("JWTSecretKey"),
                    configuration.GetValue<int>("JWTLifespan")
                )
            );

        }
    }
}
