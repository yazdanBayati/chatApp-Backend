using Chat.Core.Domains;
using Chat.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Api.Extensions
{
    public static class DependencyExtension
    {
        public static void RegisterChatServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IUserGroupRepository, UserGroupRepository>();
            
        }
    }
}
