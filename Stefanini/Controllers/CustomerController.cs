using Stefanini.Dtos;
using Stefanini.Models;
using Stefanini.service;
using Stefanini.serviceInterface;
using Stefanini.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stefanini.Controllers
{
    [SessionCheck]
    public class CustomerController : Controller
    {        
        private ICustomerService customerService;        

        public CustomerController() {
            customerService = new CustomerService();            
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult getGenders() {

            Gender[] genders = customerService.getGenders();

            return Json(genders);
        }

        [HttpPost]
        public JsonResult getRegions()
        {
            Region[] regions = customerService.getRegions();

            return Json(regions);
        }

        [HttpPost]
        public JsonResult getCities(String regionId)
        {
            City[] cities = { };
            try
            {
                int requestedRegionId = Convert.ToInt32(regionId);
                cities = customerService.getCities(requestedRegionId);
            }
            catch (Exception e) {
                //Nothing to do                
            }

            return Json(cities);
        }

        [HttpPost]
        public JsonResult getClassifications()
        {

            Classification[] classifications = customerService.getClassifications();

            return Json(classifications);
        }

        [HttpPost]
        public JsonResult getSellers() {

            UserSys[] sellers = { };
            bool isUserAdmin = Convert.ToBoolean(Session["user.isAdmin"]);

            if (isUserAdmin)
                sellers = customerService.getSellers();

            return Json(sellers);
        }

        [HttpPost]
        public JsonResult getCustomers(CustomerFiltersDTO dto)
        {            
            dto.isUserAdmin = Convert.ToBoolean(Session["user.isAdmin"]);
            dto.userId = Convert.ToInt32(Session["user.id"]);

            Customer[] customersArray = customerService.getCustomers(dto);

            return Json(customersArray);
        }
    }
}