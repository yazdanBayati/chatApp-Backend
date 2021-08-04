using System.ComponentModel.DataAnnotations;

namespace Chat.ApplicationService.Dtos
{
    public class ChatGroupDto : BaseDto
    {

        [Required(ErrorMessage = "Title is a required field.")]
        [MaxLength(50, ErrorMessage = "Max Length for Title is 50 characters.")]
        [StringLength(50)]
        public string Title { get; set; }
    }
}
