using Chat.Api.Core.Domains;
using Chat.Core.Domains;

namespace Chat.DataAccess.Repositories
{
    public class GroupRepository : BaseRepository<ChatGroup>, IGroupRepository
    {
        public GroupRepository(ChatDbContext ctx)
          : base(ctx)
        {
        }
    }
}
