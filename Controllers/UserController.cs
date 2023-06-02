using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Footty.Data;
using footty.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace footty.Controllers
{
    public class UserController : Controller
    {
        private readonly FoottyContext _context;

        public UserController(FoottyContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var passwordHash = FoottyContext.CalculateMD5Hash(password);
            var user = _context.User?.Include(u => u.favTeam).FirstOrDefault(u => u.username == username);
            if (this.IsUserWithPasswordExists(user, passwordHash))
            {
                HttpContext.Session.SetString("id", user!.id.ToString());
                HttpContext.Session.SetString("isLogged", "True");
                HttpContext.Session.SetString("canEdit", user!.can_edit.ToString());
                if (user.favTeam != null) {
                    HttpContext.Session.SetString("favTeam", user.favTeam!.name!.ToString());
                } else {
                    HttpContext.Session.SetString("favTeam", "null");
                }
                return LocalRedirect("/Home");
            } else {
                ViewBag.ErrorMessage = "Incorrect username or password.";
                return View();
            }
        }

        private bool IsUserWithPasswordExists(User? user, string passwordMd5)
        {
            if (user != null)
            {
                return AreMd5HashesEqual(passwordMd5, user.password ?? "");
            }

            return false;
        }

        private static bool AreMd5HashesEqual(string hash1, string hash2)
        {
            return StringComparer.OrdinalIgnoreCase.Compare(hash1, hash2) == 0;
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("isLogged");
            HttpContext.Session.Remove("canEdit");
            return RedirectToAction("Login");
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
              return _context.User != null ? 
                          View(await _context.User.Include(u => u.favTeam).ToListAsync()) :
                          Problem("Entity set 'FoottyContext.User'  is null.");
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.favTeam)
                .FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public async Task<IActionResult> Create()
        {
            var teams = await _context.Team.ToListAsync();
            var selectListItems = new List<SelectListItem>();

            if (teams != null)
            {
                foreach (var team in teams)
                {
                    selectListItems.Add(new SelectListItem
                    {
                        Value = team.id.ToString(),
                        Text = team.name
                    });
                }
            }

            ViewBag.teams = selectListItems;
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,username,password,can_edit,favTeam")] User user, IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                String favTeamId = form["favTeam"]!;
                Team? team = null;
                if (favTeamId != "-1") {
                    team = _context.Team.Where(t => t.id == int.Parse(favTeamId)).First();
                } else {
                    team = _context.Team.First();
                }
                _context.Add(new User { 
                    id = user.id,
                    username = user.username,
                    password = FoottyContext.CalculateMD5Hash(user.password ?? ""),
                    can_edit = user.can_edit,
                    token = FoottyContext.GenerateToken(),
                    favTeam = team
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            
            var teams = await _context.Team.ToListAsync();
            var selectListItems = new List<SelectListItem>();

            if (teams != null)
            {
                foreach (var team in teams)
                {
                    selectListItems.Add(new SelectListItem
                    {
                        Value = team.id.ToString(),
                        Text = team.name
                    });
                }
            }

            ViewBag.teams = selectListItems;
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,username,password,can_edit,favTeam")] User user, IFormCollection form)
        {   
 
            if (id != user.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    String favTeamId = form["favTeam"]!;
                    Team? team = null;
                    if (favTeamId != "-1") {
                        team = _context.Team.Where(t => t.id == int.Parse(favTeamId)).First();
                        String user_id = HttpContext.Session.GetString("id")!;
                        if (int.Parse(user_id) == id) {
                            HttpContext.Session.SetString("favTeam", team.name!.ToString());
                        }
                    }
                    User u = _context.User.Where(u => u.id == id)
                        .Include(u => u.favTeam)
                        .First();
                    u.username = user.username;
                    if (u.password != user.password) {
                        u.password = FoottyContext.CalculateMD5Hash(user.password ?? "");
                    }
                    u.can_edit = user.can_edit;
                    u.favTeam = team;
                    HttpContext.Session.SetString("canEdit", user!.can_edit.ToString());
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.id))
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
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'FoottyContext.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.User?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
