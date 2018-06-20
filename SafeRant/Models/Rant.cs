using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeRant.Models
{
    public class Rant
    {
        public int Id {get; set;}
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Target { get; set; }
        public string Body { get; set; }
        public bool IsFavorite {get; set;}
    }
}