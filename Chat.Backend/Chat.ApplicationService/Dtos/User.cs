using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chat.ApplicationService.Dtos
{
    public class UserDto : BaseDto
    {
        [Required(ErrorMessage = "UserName is a required field.")]
        [MaxLength(50, ErrorMessage = "Max Length for UserName is 50 characters.")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is a required field.")]
        [MaxLength(50, ErrorMessage = "Max Length for Password is 50 characters.")]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
