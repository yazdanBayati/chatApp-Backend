using Chat.Api.Core.Domains;
using Chat.Core.Domains;

namespace Chat.DataAccess.Repositories
{
    public class MessageRepository : BaseRepository<ChatMessage>, IMessageRepository
    {
        public MessageRepository(ChatDbContext ctx)
          : base(ctx)
        {
        }
    }
}
