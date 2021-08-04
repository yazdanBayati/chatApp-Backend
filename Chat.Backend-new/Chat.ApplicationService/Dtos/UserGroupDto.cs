using System.ComponentModel.DataAnnotations;


namespace Chat.ApplicationService.Dtos
{
    public class UserGroupDto : BaseDto
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
    }
}
