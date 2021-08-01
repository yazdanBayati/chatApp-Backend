using Chat.Api.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chat.Core.Domains
{
    public interface IMessageRepository:IBaseRepository<ChatMessage>
    {
    }
}