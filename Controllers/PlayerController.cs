using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Footty.Data;
using footty.Models;

namespace footty.Controllers
{
    public class PlayerController : Controller
    {
        private readonly FoottyContext _context;

        public PlayerController(FoottyContext context)
        {
            _context = context;
        }

        // GET: Player
        public async Task<IActionResult> Index()
        {
            var players = await _context.Player.Include(p => p.team).ToListAsync();

            string[] teams = players.Select(p => p.team!.name).Distinct().ToArray()!;
            ViewData["teams"] = teams;

            if (HttpContext.Session.Keys.Contains("order")) {
                var orderType = HttpContext.Session.GetString("order");
                if (orderType == "goals_desc") {
                    players = players.OrderByDescending(p => p.goals_scored).ToList();
                    ViewData["orderText"] = "By goals desc";
                } else if (orderType == "goals_asc") {
                    players = players.OrderBy(p => p.goals_scored).ToList();
                    ViewData["orderText"] = "By goals asc";
                } else if (orderType == "games_desc") {
                    players = players.OrderByDescending(p => p.games_played).ToList();
                    ViewData["orderText"] = "By games played desc";
                } else if (orderType == "games_asc") {
                    players = players.OrderBy(p => p.games_played).ToList();
                    ViewData["orderText"] = "By games played asc";
                } else {
                    ViewData["orderText"] = "Default";
                }
                ViewData["order"] = orderType;
            } else {
                ViewData["order"] = "default";
                ViewData["orderText"] = "Default";
            }

            if (HttpContext.Session.Keys.Contains("club")) {
                var team = HttpContext.Session.GetString("club");
                players = players.Where(p => p.team!.name == team).ToList();
                HttpContext.Session.SetString("club", team!);
                @ViewData["team"] = team;
            } else {
                @ViewData["team"] = "";
            }

            return _context.Player != null ? 
                          View(players) :
                          Problem("Entity set 'FoottyContext.Player'  is null.");
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection form)
        {
            var players = await _context.Player.Include(p => p.team).ToListAsync();

            string[] teams = players.Select(p => p.team!.name).Distinct().ToArray()!;
            ViewData["teams"] = teams;

            var orderType = form["order"];
            if (orderType == "goals_desc") {
                players = players.OrderByDescending(p => p.goals_scored).ToList();
                ViewData["orderText"] = "By goals desc";
            } else if (orderType == "goals_asc") {
                players = players.OrderBy(p => p.goals_scored).ToList();
                ViewData["orderText"] = "By goals asc";
            } else if (orderType == "games_desc") {
                players = players.OrderByDescending(p => p.games_played).ToList();
                ViewData["orderText"] = "By games played desc";
            } else if (orderType == "games_asc") {
                players = players.OrderBy(p => p.games_played).ToList();
                ViewData["orderText"] = "By games played asc";
            }else {
                ViewData["orderText"] = "Default";
            }
            ViewData["order"] = orderType;

            HttpContext.Session.SetString("order", orderType!);

            var team = form["team"];
            if (team != "") {
                players = players.Where(p => p.team!.name == team).ToList();
                HttpContext.Session.SetString("club", team!);
            } else {
                if (HttpContext.Session.Keys.Contains("club")) {
                    HttpContext.Session.Remove("club");
                }
            }
            @ViewData["team"] = team;

            return _context.Player != null ? 
                          View(players) :
                          Problem("Entity set 'FoottyContext.Player'  is null.");
        }

        // GET: Player/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Player == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .Include(p => p.team)
                .FirstOrDefaultAsync(m => m.id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        public async Task<IActionResult> Compare(int id)
        {
            var players = await _context.Player.Include(p => p.team).ToListAsync();

            if (HttpContext.Session.Keys.Contains("to_compare")) {
                int old_id = (int)HttpContext.Session.GetInt32("to_compare")!;

                HttpContext.Session.Remove("to_compare");

                ViewData["compare"] = "yes";
                ViewData["first"] = old_id;
                ViewData["second"] = id;
                players = players.Where(p => p.id == old_id || p.id == (int)id!).ToList();

                return View(players);
            } else {
                HttpContext.Session.SetInt32("to_compare", (int)id!);

                ViewData["compare"] = "no";

                players = players.Where(p => p.id != id).ToList();

                string[] teams = players.Select(p => p.team!.name).Distinct().ToArray()!;
                ViewData["teams"] = teams;

                if (HttpContext.Session.Keys.Contains("order")) {
                    var orderType = HttpContext.Session.GetString("order");
                    if (orderType == "goals_desc") {
                        players = players.OrderByDescending(p => p.goals_scored).ToList();
                        ViewData["orderText"] = "By goals desc";
                    } else if (orderType == "goals_asc") {
                        players = players.OrderBy(p => p.goals_scored).ToList();
                        ViewData["orderText"] = "By goals asc";
                    } else if (orderType == "games_desc") {
                        players = players.OrderByDescending(p => p.games_played).ToList();
                        ViewData["orderText"] = "By games played desc";
                    } else if (orderType == "games_asc") {
                        players = players.OrderBy(p => p.games_played).ToList();
                        ViewData["orderText"] = "By games played asc";
                    } else {
                        ViewData["orderText"] = "Default";
                    }
                    ViewData["order"] = orderType;
                } else {
                    ViewData["order"] = "default";
                    ViewData["orderText"] = "Default";
                }

                if (HttpContext.Session.Keys.Contains("club")) {
                    var team = HttpContext.Session.GetString("club");
                    players = players.Where(p => p.team!.name == team).ToList();
                    HttpContext.Session.SetString("club", team!);
                    @ViewData["team"] = team;
                } else {
                    @ViewData["team"] = "";
                }

                return View(players);
            }
            
        }

        // GET: Player/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?Linkid=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,team,position,shirt_number,minutes_played,games_played,goals_scored")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Player/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Player == null)
            {
                return NotFound();
            }

            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?Linkid=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,team,position,shirt_number,minutes_played,games_played,goals_scored")] Player player)
        {
            if (id != player.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Player/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Player == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .FirstOrDefaultAsync(m => m.id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Player == null)
            {
                return Problem("Entity set 'FoottyContext.Player'  is null.");
            }
            var player = await _context.Player.FindAsync(id);
            if (player != null)
            {
                _context.Player.Remove(player);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
          return (_context.Player?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
