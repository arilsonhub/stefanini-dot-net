using Stefanini.Dao;
using Stefanini.Dtos;
using Stefanini.Models;
using Stefanini.Repository;
using Stefanini.serviceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Stefanini.service
{
    public class AutenticationService : IAutenticationService
    {

        private UserSysRepository userSysRepository;

        public AutenticationService() {
            userSysRepository = new UserSysDAO();
        }

        public void Autenticate(AutenticationDTO autenticationDTO)
        {

            UserSys userSys = autenticationDTO.userSys;
            String returnUrl = autenticationDTO.returnUrl;
            UserSys userLogged = userSysRepository.getUserByLoginAndPassword(userSys.email, userSys.password);           

            if (userLogged != null)
            {
                FormsAuthentication.SetAuthCookie(userLogged.login, false);
                if (autenticationDTO.isLocalURL
                && returnUrl.Length > 1
                && returnUrl.StartsWith("/")
                && !returnUrl.StartsWith("//")
                && returnUrl.StartsWith("/\\"))
                {
                    autenticationDTO.redirectToReturnURL = true;
                    return;
                }

                autenticationDTO.userLogged = userLogged;                
            }
            else
            {
                autenticationDTO.loginFailMessage = "The email and/or password entered is invalid. Please try again.";
            }
        }
    }
}