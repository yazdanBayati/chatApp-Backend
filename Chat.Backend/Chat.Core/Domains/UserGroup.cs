using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Core.Domains
{
    public class UserGroup:BaseEntity
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
    }
}
