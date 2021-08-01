using Chat.Core.Domains;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Chat.Api.Core.Domains
{
    public class ChatMessageDto: BaseDto
    {
        [Required(ErrorMessage = "User is a required field.")]
        [MaxLength(50, ErrorMessage = "Max Length for User is 50 characters.")]
        [StringLength(50)]
        public string User { get; set; }
        [Required(ErrorMessage = "Message is a required field.")]
        [MaxLength(200, ErrorMessage = "Max Length for Message is 50 characters.")]
        [StringLength(200)]
        public string Message { get; set; }
        [Required(ErrorMessage = "GroupName is a required field.")]
        [MaxLength(50, ErrorMessage = "Max Length for GroupName is 50 characters.")]
        [StringLength(50)]
        public string GroupName { get; set; }// use this field in hub
        public int GroupId { get; set; }
    }
}
