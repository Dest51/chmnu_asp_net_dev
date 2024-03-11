using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Topchii_lr6.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Topchii_lr6.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        [Route("/Home/Register")]
        public IActionResult Register(User user)
        {

            if (ModelState.IsValid)
            {
                if (user.Age < 16)
                {
                    ModelState.AddModelError("Age", "Вік має бути більше 16 років");
                    return View("Index", user);
                }


                return RedirectToAction("Order", "Product");
            }

            return View("Index", user);
        }
    }
}

