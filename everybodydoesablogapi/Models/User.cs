using everybodydoesablogapi.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace everybodydoesablogapi.Models
{
    public class User : LinkedResourceBase
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
