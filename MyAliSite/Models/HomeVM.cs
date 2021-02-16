using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAliSite.Models
{
    public class HomeVM
    {
        public Dictionary<string, string> NavCategories { get; set; }
        public Dictionary<string, string> Links { get; set; }
        public string Content { get; set; }
    }
}