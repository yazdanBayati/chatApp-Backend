using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Api.Core.Domains
{
    public class ChatMessage
    {
        public string User { get; set; }

        public string Message { get; set; }
    }
}
