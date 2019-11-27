using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebVideoDomain.Models
{
    public class Filter
    {
        public string Name { get; set; }
        public  Level Level { get; set; }
        public string Course { get; set; }
        public string Author { get; set; }
    }
}