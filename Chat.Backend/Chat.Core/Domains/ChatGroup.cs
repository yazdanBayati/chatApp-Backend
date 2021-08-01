using Chat.Core.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Api.Core.Domains
{
    public class ChatGroup:BaseEntity
    {
        [Column(TypeName = "NVARCHAR(50)")]
        public string Title { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string Name { get; set; }
    }
}
