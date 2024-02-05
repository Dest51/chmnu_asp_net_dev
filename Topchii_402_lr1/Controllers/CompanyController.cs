using Microsoft.AspNetCore.Mvc;
using Topchii_402_lr.Models;

namespace Topchii_402_lr.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{
    private readonly Company _company;

    public CompanyController()
    {
        _company = new Company
        {
            Name = "ArTem inc.",
            Industry = "App development",
            Location = "Ukraine",
            EmployeesCount = 23

        };
    }

    [HttpGet]
    public ActionResult GetCompanyInfo()
    {
        return Ok(new
        {
            Name = _company.Name,
            Industry = _company.Industry,
            Location = _company.Location,
            EmployeesCount = _company.EmployeesCount
        });
    }

    [HttpGet("randNumber")]
    public IActionResult GetRandomNumber()
    {
        Random random = new Random();
        int randomNumber = random.Next(0, 101);
        return Ok(randomNumber);
    }
}

