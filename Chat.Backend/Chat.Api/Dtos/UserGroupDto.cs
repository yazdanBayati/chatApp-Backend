using Chat.Core.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chat.Api.Dtos
{
    public class UserGroupDto : BaseDto
    {
        [Required(ErrorMessage = "GroupName is a required field.")]
        [MaxLength(50, ErrorMessage = "Max Length for GroupName is 50 characters.")]
        [StringLength(50)]
        public string GroupName { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
    }
}
