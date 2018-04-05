using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.DataContext;
using WebApp.Models;
using WebApp.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new WebAppDbContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id.Equals(model.Id)
                                                        && u.Password.Equals(model.Password));
                    if (user != null) // Login Success
                    {
                        return RedirectToAction("LoginSuccess", "Home");
                    }
                } 
                // Login Failed
                ModelState.AddModelError(string.Empty, "Incorrect ID or Password");
            }
            return View(model);
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                //try catch
                using (var db = new WebAppDbContext())
                {
                    db.Users.Add(model);    // update in memory
                    db.SaveChanges();       // save in sql
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
