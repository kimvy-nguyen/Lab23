using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab23OK.Models;

namespace Lab23OK.Controllers
{
    public class LoginController : Controller
    {
        ShopContext db = new ShopContext();
        //may have to change using statement if red underline

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Register(Users u)
        {
            if (db.Users.Contains(u))
            {
                ViewBag.Error = "That user already exists";
                return View();
            }
            else
            {
                db.Users.Add(u);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(string UserName, string Password)
        {
            List<Users> users = db.Users.ToList();

            for(int i =0; i <users.Count; i++)
            {
                Users u = users[i];
                if(u.UserName == UserName && u.Password == Password)
                {
                    //login the user
                    TempData["User"] = u;
                }
            }

            ViewBag.Error = "Incorrect Username or Password, please register or try again.";
            return RedirectToAction("Index","Home");
        }

    }
}
