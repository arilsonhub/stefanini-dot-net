using Stefanini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stefanini.Dtos
{
    public class AutenticationDTO
    {
        public UserSys userSys { get; set; }
        public String returnUrl { get; set; }

        public bool isLocalURL { get; set; }

        public bool redirectToReturnURL { get; set; }

        public UserSys userLogged { get; set; }

        public String loginFailMessage { get; set; }
    }
}