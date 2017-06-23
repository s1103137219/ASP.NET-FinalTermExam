using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class CustomerController : Controller
    {
        Models.CodeService codeservice = new Models.CodeService();

        public ActionResult Index()
        {

            ViewBag.contacttitle = codeservice.GetContactTitle();
            Models.CustomerService customerService = new Models.CustomerService();
            ViewBag.Data = customerService.GetCustomerById("");
            return View();

        }

        [HttpPost()]
        public ActionResult Index(Models.CustomerSearchArg data)
        {

            Models.CustomerService customerService = new Models.CustomerService();

            if (data.delbtn != null)
            {
                customerService.DeleteOrderCustomerById(data.delbtn);
            }
            else if (data.editbtn != null)
            {
               
            }
            else
            {
                ViewBag.Data = customerService.GetOrderByCondtioin(data);
            }

            return View("Index");

        }
	}
}