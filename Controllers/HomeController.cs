using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using footty.Models;
using Footty.Data;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;


namespace footty.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly FoottyContext _context;


    public HomeController(ILogger<HomeController> logger, FoottyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
         var team = HttpContext.Session.GetString("favTeam");
        var list = await _context.Match
                                .Include(m => m.team)
                                .Include(m => m.opponent)
                                .ToListAsync();
        
        list = list.Where(p => (p.team!.name == team || p.opponent!.name == team) && p.place=="Home")
                    .OrderByDescending(p => p.date)
                    .Take(5).ToList();


        var players = await _context.Player.Include(p => p.team).ToListAsync();

        players = players.Where(p => p.team!.name == team).OrderByDescending(p => p.goals_scored).Take(8).ToList();

        var stadiums = await _context.Stadium.Include(s => s.team).ToListAsync();
        string longitude = stadiums.Where(p => p.team!.name == team).Select(p => p.longitude).First().ToString();
        string latitude = stadiums.Where(p => p.team!.name == team).Select(p => p.latitude).First().ToString();



        ViewData["fav_team"] = team;
        ViewData["long"] = longitude.Replace(",", ".");
        ViewData["lat"] = latitude.Replace(",", ".");
        ViewData["scorers"] = players;
        return View(list);
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
