using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Topchii_402_lr8.Models;


namespace Topchii_402_lr8.Controllers
{
    public class ProductController : Controller
    {
        Random random = new Random();

        public IActionResult Index()
        {
            var products = new List<ProductModel>
            {

                new ProductModel { ID = 1, Name = "Зарядна станція EcoFlow RIVER Pro", Price = "15399 грн", CreatedDate = DateTime.Now.AddDays(random.Next(-10, 10)) },
                new ProductModel { ID = 2, Name = "Сонячна панель Axioma AXM108-16-182-430N", Price = "6900 грн", CreatedDate = DateTime.Now.AddDays(random.Next(-10, 10)) },
                new ProductModel { ID = 3, Name = "Маршрутизатор MikroTik RB2011IL-IN", Price = "4680 грн", CreatedDate = DateTime.Now.AddDays(random.Next(-10, 10)) },
                new ProductModel { ID = 4, Name = "Мобільний телефон Xiaomi 12T Pro", Price = "23999 грн", CreatedDate = DateTime.Now.AddDays(random.Next(-10, 10)) },
                new ProductModel { ID = 5, Name = "Ноутбук Lenovo ThinkPad X1 Carbon Gen 10", Price = "55999 грн", CreatedDate = DateTime.Now.AddDays(random.Next(-10, 10)) },
                new ProductModel { ID = 6, Name = "Електросамокат Xiaomi Mi Electric Scooter Pro 2", Price = "19999 грн", CreatedDate = DateTime.Now.AddDays(random.Next(-10, 10)) },
                new ProductModel { ID = 7, Name = "Бездротові навушники Sony WH-1000XM5", Price = "12999 грн", CreatedDate = DateTime.Now.AddDays(random.Next(-10, 10)) },
                new ProductModel { ID = 8, Name = "Робот-пилосос Xiaomi Roborock S7 MaxV Ultra", Price = "34999 грн", CreatedDate = DateTime.Now.AddDays(random.Next(-10, 10)) },
                new ProductModel { ID = 9, Name = "Телевізор Samsung QLED Q80A 55", Price = "44999 грн", CreatedDate = DateTime.Now.AddDays(random.Next(-10, 10)) }
    
            };

            return View(products);
        }

    }
}

