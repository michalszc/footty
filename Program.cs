using Microsoft.EntityFrameworkCore;
using Footty.Data;


List<string> forbiddenActions = new List<string>{"Create", "Delete", "Edit"};
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FoottyContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("FoottyContext") ?? throw new InvalidOperationException("Connection string 'FoottyContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();


app.Use(async (ctx, next) =>
{
    bool isLogged = string.Equals(ctx.Session.GetString("isLogged"), "True");
    bool canEdit = string.Equals(ctx.Session.GetString("canEdit"), "True");
    string path = ctx.Request.Path.ToString();

    if (!isLogged && path != "/User/Login" && path != "/User/Logout" && !path.Split("/").Contains("api"))
    {
        ctx.Response.Redirect("/User/Login");
        return;
    } else if (ctx.Response.StatusCode == 404 || (!canEdit && (forbiddenActions.Contains(path.Split("/").Last()) || path == "/User" || path == "/User/Index") )) {
        ctx.Response.Redirect("/Home/Index");
        return;
    }

    await next(ctx);
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// api 
app.MapGet("/api/matches/{id}/{nick}/{token}", async (int id, string nick, string? token, FoottyContext db) =>
{
    bool access = db.User.Where(p => p.username == nick).Select(p => p.can_edit).First();
    string? key = db.User.Where(p => p.username == nick).Select(p => p.token).First();
    access = (token == key) && access;
    if (!access) {
        return Results.Unauthorized();
    }
    return Results.Ok(await db.Match
                        .Include(m => m.team)
                        .Include(m => m.opponent)
                        .Where(m => m.id == id)
                        .ToListAsync());
    
});

app.MapGet("/api/teams/{id}/{nick}/{token}", async (int id, string nick, string? token, FoottyContext db) =>
{
    bool access = db.User.Where(p => p.username == nick).Select(p => p.can_edit).First();
    string? key = db.User.Where(p => p.username == nick).Select(p => p.token).First();
    access = (token == key) && access;
    if (!access) {
        return Results.Unauthorized();
    }
    return Results.Ok(await db.Team
                        .Where(m => m.id == id)
                        .ToListAsync());
    
});


app.MapPost("/api/teams/{name}/{nick}/{token}", async (string name, string nick, string? token, FoottyContext db) => 
{
    bool access = db.User.Where(p => p.username == nick).Select(p => p.can_edit).First();
    string? key = db.User.Where(p => p.username == nick).Select(p => p.token).First();
    access = (token == key) && access;
    if (!access) {
        return Results.Unauthorized();
    }
    footty.Models.Team team = new footty.Models.Team{name = name};
    db.Team.Add(team);
    await db.SaveChangesAsync();

    return Results.Created($"/api/teams/{team.id}/{nick}/{token}", team);
});

app.Run();
