using System.ComponentModel.DataAnnotations;

namespace Chat.ApplicationService.Dtos
{
    public class ChatMessageDto : BaseDto
    {
        [Required(ErrorMessage = "User is a required field.")]
        [MaxLength(50, ErrorMessage = "Max Length for User is 50 characters.")]
        [StringLength(50)]
        public string User { get; set; }
        [Required(ErrorMessage = "Message is a required field.")]
        [MaxLength(200, ErrorMessage = "Max Length for Message is 50 characters.")]
        [StringLength(200)]
        public string Message { get; set; }
        public int GroupId { get; set; }
    }
}
