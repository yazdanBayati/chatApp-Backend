using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chat.Core.Domains
{
    public class User:BaseEntity
    {
        [Column(TypeName = "NVARCHAR(50)")]
        public string UserName { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string Password { get; set; }
    }
}
