﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace everybodydoesablogapi.Resources
{
    public class Link
    {
        
        public string Href { get; private set; }
        public string Rel { get; private set;  }
        public string Method { get; private set; }

        public Link(string href, string rel, string method)
        {
            
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
}