using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //var firstUser = new User
            //{
            //    No = 1,
            //    Name = "Inhyup"
            //};

            ////ViewBag.User = firstUser;

            //ViewData["User"] = firstUser;
            return View();
        }

        public IActionResult LoginSuccess()
        {
            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
