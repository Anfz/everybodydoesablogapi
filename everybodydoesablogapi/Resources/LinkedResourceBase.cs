using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace everybodydoesablogapi.Resources
{
    /// <summary>
    /// Made abstract so other can use it 
    /// </summary>
    public abstract class LinkedResourceBase
    {
        [NotMapped]
        public List<Link> Links { get; set; }
        = new List<Link>();
    }
}
