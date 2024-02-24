using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;

namespace Library
{

    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return Content("Вітаємо у бібліотеці!");
        }

        public IActionResult Books()
        {
            var books = _configuration.GetSection("Books").Get<List<string>>();

            return new ObjectResult(books);
        }

        public IActionResult Profile(int? id)
        {
            var userInfo = "";

            if (id.HasValue && id >= 0 && id <= 5)
            {
                userInfo = _configuration.GetSection($"Users:{id}").Value;
            }
            else
            {
                userInfo = _configuration.GetSection("Users:BaseUser").Value;
            }

            return new ObjectResult(userInfo);


        }
    }

}