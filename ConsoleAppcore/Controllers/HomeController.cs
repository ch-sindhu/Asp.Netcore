using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using ConsoleAppcore.Models;

namespace ConsoleAppcore.Controllers
{
    public class HomeController:Controller
    {
         public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }

    }
}
