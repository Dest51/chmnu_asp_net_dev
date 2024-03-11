using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Topchii_lr6.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Order(int quantity)
        {
            if (ModelState.IsValid)
            {
                if (quantity <= 0)
                {
                    ModelState.AddModelError("quantity", "Кількість товарів має бути більше 0");
                    return View();
                }

                // Зберегти замовлення в базу даних

                // Відобразити інформацію про замовлення

                return View("OrderConfirmation");
            }

            return View();
        }
    }
}

