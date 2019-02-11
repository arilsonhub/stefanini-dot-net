using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stefanini.Models
{
    public class UserSys
    {
        public int id { get; set; }
        public String login { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public int userRoleId { get; set; }
        public UserRole userRole { get; set; }       
    }
}