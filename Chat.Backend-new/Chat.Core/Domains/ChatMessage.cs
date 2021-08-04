using Chat.Core.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Api.Core.Domains
{
    public class ChatMessage: BaseEntity
    {
        [Column(TypeName = "NVARCHAR(50)")]
        public string User { get; set; }
        [Column(TypeName = "NVARCHAR(200)")]
        public string Message { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public int GroupId { get; set; }
    }
}
