using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace everybodydoesablogapi.Models
{
    public class Post
    {
        [Key]
        public Guid PostId { get; set; }
        [Required]
        public string Title { get; set; }

        public string Contents { get; set; }

        public DateTime CreationDate { get; set; }

        [ForeignKey("BlogId")]
        public Guid BlogId { get; set; }
    }
}
