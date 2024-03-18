using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Topchii_402_lr7.Models;

namespace Topchii_402_lr7.Controllers;

public class FileController : Controller
{
    private readonly ILogger<FileController> _logger;

    public FileController(ILogger<FileController> logger)
    {
        _logger = logger;
    }

    public IActionResult DownloadFile()
    {
        return View(new FileViewModel()); 
    }

    [HttpPost]
    public IActionResult DownloadFile(FileViewModel model)
    {
        // Генеруємо вміст файлу
        string fileContent = $"Ім'я: {model.FirstName}\nПрізвище: {model.LastName}";

        // Записуємо вміст файлу
        byte[] fileBytes = Encoding.UTF8.GetBytes(fileContent);
        return File(fileBytes, "text/plain", $"{model.FileName}.txt");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

