using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using footty.Models;

namespace footty.Controllers;

public class Teams : Controller {
    public IActionResult Index()
    {
        return View();
    }
}