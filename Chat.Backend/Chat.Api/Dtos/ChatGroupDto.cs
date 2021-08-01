using Chat.Core.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Api.Core.Domains
{
    public class ChatGroupDto : BaseDto
    {

        [Required(ErrorMessage = "Title is a required field.")]
        [MaxLength(50, ErrorMessage = "Max Length for Title is 50 characters.")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(50, ErrorMessage = "Max Length for Name is 50 characters.")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
