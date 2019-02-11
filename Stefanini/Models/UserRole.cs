using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Stefanini.Models
{   
    public class UserRole
    {
        public int id { get; set; }
        public String name { get; set; }
        public bool isAdmin { get; set; }        
    }
}