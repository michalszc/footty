using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using footty.Models;

namespace footty.Controllers;

public class Stadions : Controller {
    public IActionResult Index()
    {
        return View();
    }
}