using Lab23OK.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab23OK.Controllers
{
    public class ProductController : Controller
    {
        ShopContext db = new ShopContext();

        public IActionResult Index()
        {
            List<Products> products = db.Products.ToList();
            return View(db.Products.ToList());
            //maybe put just products in parentheses
        }

        //maybe change this whole file to products controller???

        public IActionResult Buy(int id)
        {
            Products p = db.Products.Find(id);
            if(p!= null)
            {
                return View(p);
            }
            else
            {
               return RedirectToAction("Index", "Products");
            }
        }

    }
}
