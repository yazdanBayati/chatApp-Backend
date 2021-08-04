using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chat.ApplicationService.Dtos
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        //public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
