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
    public class StadiumController : Controller
    {
        private readonly FoottyContext _context;

        public StadiumController(FoottyContext context)
        {
            _context = context;
        }

        // GET: Stadium
        public async Task<IActionResult> Index()
        {
            var stadiums = await _context.Stadium.Include(s => s.team).ToListAsync();

            string[] cities = stadiums.Select(p => p.city).Distinct().ToArray()!;
            ViewData["cities"] = cities;

            if (HttpContext.Session.Keys.Contains("min")) {
                stadiums = stadiums.Where(p => p.capacity >= HttpContext.Session.GetInt32("min")).ToList();
                ViewData["min"] = HttpContext.Session.GetInt32("min");
            }
            if (HttpContext.Session.Keys.Contains("max")) {
                stadiums = stadiums.Where(p => p.capacity <= HttpContext.Session.GetInt32("max")).ToList();
                ViewData["max"] = HttpContext.Session.GetInt32("max");
            }
            if (HttpContext.Session.Keys.Contains("city")) {
                stadiums = stadiums.Where(p => p.city == HttpContext.Session.GetString("city")).ToList();
                ViewData["city"] = HttpContext.Session.GetString("city");
            } else {
                ViewData["city"] = "";
            }

            return _context.Stadium != null ? 
                          View(stadiums) :
                          Problem("Entity set 'FoottyContext.Stadium'  is null.");
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection form) {
            var stadiums = await _context.Stadium.Include(s => s.team).ToListAsync();

            string[] cities = stadiums.Select(p => p.city).Distinct().ToArray()!;
            ViewData["cities"] = cities;

            var minStr = form["min"].ToString();
            var maxStr = form["max"].ToString();
            var city = form["city"].ToString();

            ViewData["min"] = minStr;
            ViewData["max"] = maxStr;
            ViewData["city"] = city;

            if (minStr != "") {
                int min = Int32.Parse(minStr);
                stadiums = stadiums.Where(p => p.capacity >= min).ToList();
                HttpContext.Session.SetInt32("min", min);
            } else {
                if (HttpContext.Session.Keys.Contains("min")) {
                    HttpContext.Session.Remove("min");
                }
            }
            if (maxStr != "") {
                int max = Int32.Parse(maxStr);
                stadiums = stadiums.Where(p => p.capacity <= max).ToList();
                HttpContext.Session.SetInt32("max", max);
            } else {
                 if (HttpContext.Session.Keys.Contains("max")) {
                    HttpContext.Session.Remove("max");
                }
            }
            if (city != "") {
                stadiums = stadiums.Where(p => p.city == city).ToList();
                HttpContext.Session.SetString("city", city);
            } else {
                 if (HttpContext.Session.Keys.Contains("city")) {
                    HttpContext.Session.Remove("city");
                }
            }

            return _context.Stadium != null ? 
                          View(stadiums) :
                          Problem("Entity set 'FoottyContext.Stadium'  is null.");
        }

        // GET: Stadium/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stadium == null)
            {
                return NotFound();
            }

            var stadium = await _context.Stadium
                .Include(s => s.team)
                .FirstOrDefaultAsync(m => m.id == id);
            if (stadium == null)
            {
                return NotFound();
            }

            return View(stadium);
        }

        // GET: Stadium/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stadium/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?Linkid=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,team,city,name,capacity,latitude,longitude")] Stadium stadium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stadium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stadium);
        }

        // GET: Stadium/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stadium == null)
            {
                return NotFound();
            }

            var stadium = await _context.Stadium.FindAsync(id);
            if (stadium == null)
            {
                return NotFound();
            }
            return View(stadium);
        }

        // POST: Stadium/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?Linkid=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,team,city,name,capacity,latitude,longitude")] Stadium stadium)
        {
            if (id != stadium.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stadium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StadiumExists(stadium.id))
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
            return View(stadium);
        }

        // GET: Stadium/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stadium == null)
            {
                return NotFound();
            }

            var stadium = await _context.Stadium
                .FirstOrDefaultAsync(m => m.id == id);
            if (stadium == null)
            {
                return NotFound();
            }

            return View(stadium);
        }

        // POST: Stadium/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stadium == null)
            {
                return Problem("Entity set 'FoottyContext.Stadium'  is null.");
            }
            var stadium = await _context.Stadium.FindAsync(id);
            if (stadium != null)
            {
                _context.Stadium.Remove(stadium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StadiumExists(int id)
        {
          return (_context.Stadium?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
