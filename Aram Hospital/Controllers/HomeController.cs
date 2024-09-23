using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Services;
using System.Web;
using System.Web.Mvc;
using Aram_Hospital.Extensions;
using Aram_Hospital.Models;


namespace Aram_Hospital.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminLogin AdminLogin_obj)
        {

            return View();
        }

        public ActionResult About()
        {

            return View();
        }


        public ActionResult Docters()
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }

        




    }
}