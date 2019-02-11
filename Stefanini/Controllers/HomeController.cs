using Stefanini.Dtos;
using Stefanini.Models;
using Stefanini.service;
using Stefanini.serviceInterface;
using System;
using System.Web;
using System.Web.Mvc;

namespace Stefanini.Controllers
{
    public class HomeController : Controller
    {
        private IAutenticationService autenticationService;

        public HomeController() {
            autenticationService = new AutenticationService();
        }

        public ActionResult Index(String loginFailMessage)
        {
            ViewBag.loginFailMessage = loginFailMessage;
            return View();
        }

        public ActionResult LogOut()
        {
            Session["isLogged"] = null;
            return RedirectToAction("Index");
        }

        /// <param name="returnURL"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Autenticate(UserSys userSys, String returnUrl)
        {
            if (ModelState.IsValid)
            {
                AutenticationDTO dto = new AutenticationDTO();
                dto.isLocalURL = Url.IsLocalUrl(returnUrl);
                dto.returnUrl = returnUrl;
                dto.userSys = userSys;
                autenticationService.Autenticate(dto);

                if (dto.userLogged != null)
                {
                    if (dto.redirectToReturnURL)
                        return Redirect(returnUrl);

                    Session["isLogged"] = true;
                    Session["user.name"] = dto.userLogged.login;
                    Session["user.isAdmin"] = dto.userLogged.userRole.isAdmin;
                    Session["user.id"] = dto.userLogged.id;

                    return RedirectToAction("Index", "Customer");
                }
                else
                {                    
                    return RedirectToAction("Index", new { loginFailMessage = dto.loginFailMessage });
                }                
            }

            return RedirectToAction("Index");
        }
    }
}