using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stefanini.Models
{
    public class City
    {
        public int id { get; set; }
        public String name { get; set; }
        public int regionId { get; set; }
        public Region region { get; set; }
    }
}