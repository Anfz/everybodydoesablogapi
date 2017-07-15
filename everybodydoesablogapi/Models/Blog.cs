using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace everybodydoesablogapi.Models
{
    public class Blog
    {
        [Key]
        public Guid BlogId { get; set; }
        [Required]
        public string Title { get; set; }

        public string Summary { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }


    }
}
