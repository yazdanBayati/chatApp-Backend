using Chat.Api.Core.Domains;
using Chat.Core.Domains;
using Microsoft.EntityFrameworkCore;


namespace Chat.DataAccess
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext()
        {
        }

        public ChatDbContext(DbContextOptions<ChatDbContext> options)
            : base(options)
        {
        }

        public DbSet<ChatGroup> ChatGroups { get; set; }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
    }
}
