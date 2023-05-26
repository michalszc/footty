using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using footty.Models;

namespace footty.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult LogIn() {
        return View();
    }

    public IActionResult Teams() {
        return View();
    }

    public IActionResult Players() {
        return View();
    }

    public IActionResult Stadions() {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
