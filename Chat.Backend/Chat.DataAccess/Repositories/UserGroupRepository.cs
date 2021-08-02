using Chat.Api.Core.Domains;
using Chat.Core.Domains;

namespace Chat.DataAccess.Repositories
{
    public class UserGroupRepository : BaseRepository<UserGroup>, IUserGroupRepositroy
    {
        public UserGroupRepository(ChatDbContext ctx)
          : base(ctx)
        {
        }
    }
}
