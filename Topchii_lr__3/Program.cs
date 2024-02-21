using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MiddlewareDemo
{
    // Завдання 1: клас CalcService для арифметичних операцій
    public class CalcService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public double Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero");
            return (double)a / b;
        }
    }

    // Завдання 2: сервіс для аналізу часу і повернення відповіді
    public interface ITimeOfDayService
    {
        string GetTimeOfDay();
    }

    public class TimeOfDayService : ITimeOfDayService
    {
        public string GetTimeOfDay()
        {
            var hour = DateTime.Now.Hour;
            if (hour >= 12 && hour < 18)
                return "зараз день";
            else if (hour >= 18 && hour < 24)
                return "зараз вечір";
            else if (hour >= 0 && hour < 6)
                return "зараз ніч";
            else
                return "зараз ранок";
        }
    }

    // Контролер, який використовує CalcService через DI
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly CalcService _calcService;
        private readonly ITimeOfDayService _timeOfDayService;

        public CalculatorController(CalcService calcService, ITimeOfDayService timeOfDayService)
        {
            _calcService = calcService;
            _timeOfDayService = timeOfDayService;
        }

        [HttpGet("add")]
        public IActionResult Add(int a, int b)
        {
            var result = _calcService.Add(a, b);
            return Ok(result);
        }

        [HttpGet("subtract")]
        public IActionResult Subtract(int a, int b)
        {
            var result = _calcService.Subtract(a, b);
            return Ok(result);
        }

        [HttpGet("multiply")]
        public IActionResult Multiply(int a, int b)
        {
            var result = _calcService.Multiply(a, b);
            return Ok(result);
        }

        [HttpGet("divide")]
        public IActionResult Divide(int a, int b)
        {
            try
            {
                var result = _calcService.Divide(a, b);
                return Ok(result);
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("timeOfDay")]
        public IActionResult GetTimeOfDay()
        {
            var timeOfDay = _timeOfDayService.GetTimeOfDay();
            return Ok(timeOfDay);
        }
    }

    // Налаштування DI
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<CalcService>();
            services.AddTransient<ITimeOfDayService, TimeOfDayService>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
