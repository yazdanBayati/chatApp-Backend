using Chat.Api.Core.Domains;
using Chat.Core.Domains;

namespace Chat.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ChatDbContext ctx)
          : base(ctx)
        {
        }
    }
}
