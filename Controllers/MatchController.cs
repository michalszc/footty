using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Footty.Data;
using footty.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace footty.Controllers
{
    public class MatchController : Controller
    {
        private readonly FoottyContext _context;

        public MatchController(FoottyContext context)
        {
            _context = context;
        }

        // GET: Match
        public async Task<IActionResult> Index()
        {
            var list = await _context.Match
                                .Include(m => m.team)
                                .Include(m => m.opponent)
                                .ToListAsync();

            var fromDate = DateTime.Parse("1970-01-01");
            var toDate = DateTime.Today;
            if(HttpContext.Session.Keys.Contains("from")) {
                var from = HttpContext.Session.GetString("from"); 
                fromDate = DateTime.Parse(from!);
                ViewData["from"] = from;
            } 
            if(HttpContext.Session.Keys.Contains("to")) {
                var to = HttpContext.Session.GetString("to");
                fromDate = DateTime.Parse(to!);
                ViewData["to"] = to;
            } 
            
            
            var good = list.Where(p => 
                                    p.place == "Home"
                                    && DateTime.Parse(p.date!, new CultureInfo("pl-PL", true)) >= fromDate 
                                    && DateTime.Parse(p.date!, new CultureInfo("pl-PL", true)) <= toDate);
            
            if (HttpContext.Session.Keys.Contains("team")) {
                var team = HttpContext.Session.GetString("team");
                if (team != "" && team != "Select team") {
                    good = good.Where(p => p.team!.name == team || p.opponent!.name == team);
                }
                ViewData["team"] = team;
            } else {
                ViewData["team"] = "Select team";
            }
            
            return _context.Match != null ? 
                          View(good) :
                          Problem("Entity set 'FoottyContext.Match'  is null.");
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection form) {
            string from = form["from"].ToString();
            string to = form["to"].ToString();
            string team = form["team"].ToString();
            
            var list = await _context.Match
                                .Include(m => m.team)
                                .Include(m => m.opponent)
                                .ToListAsync();

            ViewData["from"] = from;
            ViewData["to"] = to;
            ViewData["team"] = team;

            var fromDate = DateTime.Parse("1970-01-01");
            var toDate = DateTime.Today;
            if (from != "") {
                fromDate = DateTime.Parse(from);
            }
            if (to != "") {
                toDate = DateTime.Parse(to);
            }
            
            HttpContext.Session.SetString("from", from);
            HttpContext.Session.SetString("to", to);
            HttpContext.Session.SetString("team", team);
            var good = list.Where(p => 
                                    p.place == "Home"
                                    && DateTime.Parse(p.date!, new CultureInfo("pl-PL", true)) >= fromDate 
                                    && DateTime.Parse(p.date!, new CultureInfo("pl-PL", true)) <= toDate);

            if (team != "" && team != "Select team") {
                good = good.Where(p => p.team!.name == team || p.opponent!.name == team);   
            }

            return View(good);
        }

        // GET: Match/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Match == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.team)
                .Include(m => m.opponent)
                .FirstOrDefaultAsync(m => m.id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Match/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Match/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?Linkid=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,date,team,opponent,place,team_goals,opponent_goals")] Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(match);
        }

        // GET: Match/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Match == null)
            {
                return NotFound();
            }

            var match = await _context.Match.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            return View(match);
        }

        // POST: Match/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?Linkid=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,date,team,opponent,place,team_goals,opponent_goals")] Match match)
        {
            if (id != match.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.id))
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
            return View(match);
        }

        // GET: Match/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Match == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .FirstOrDefaultAsync(m => m.id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Match/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Match == null)
            {
                return Problem("Entity set 'FoottyContext.Match'  is null.");
            }
            var match = await _context.Match.FindAsync(id);
            if (match != null)
            {
                _context.Match.Remove(match);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(int id)
        {
          return (_context.Match?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
