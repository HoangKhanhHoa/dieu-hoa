using idn.AnPhu.Website.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Areas.Auth.Controllers
{
    public class CustomerController : AdministratorController
    {
        // GET: Auth/Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}