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

app.MapPut("/api/matches/{id}/{team_goals}/{opponent_goals}/{nick}/{token}",
            async (int id, int team_goals, int opponent_goals,
                     string nick, string? token, FoottyContext db) =>
{
    bool access = db.User.Where(p => p.username == nick).Select(p => p.can_edit).First();
    string? key = db.User.Where(p => p.username == nick).Select(p => p.token).First();
    access = (token == key) && access;
    if (!access) {
        return Results.Unauthorized();
    }
    var match = await db.Match.FindAsync(id);

    if (match is null) {
        Console.WriteLine("Match");
        return Results.NotFound();
    }

    match.team_goals = team_goals;
    match.opponent_goals = opponent_goals;

    await db.SaveChangesAsync();

    return Results.NoContent();
    
});

app.MapPost("/api/matches/{date}/{team}/{opp}/{place}/{tg}/{og}/{nick}/{token}",
            async (string date, int team, int opp, string place, int tg, int og,
                     string nick, string? token, FoottyContext db) =>
{
    bool access = db.User.Where(p => p.username == nick).Select(p => p.can_edit).First();
    string? key = db.User.Where(p => p.username == nick).Select(p => p.token).First();
    access = (token == key) && access;
    if (!access) {
        return Results.Unauthorized();
    }

    var firstTeam = db.Team.Where(t => t.id == team).First();
    var secondTeam = db.Team.Where(t => t.id == opp).First();

    if (firstTeam is null || secondTeam is null) {
        return Results.NotFound();
    }

    footty.Models.Match match = new footty.Models.Match {
        date = date.Replace('_','/'),
        team = firstTeam,
        opponent = secondTeam,
        place = place,
        team_goals = tg,
        opponent_goals = og
    };

    db.Match.Add(match);
    await db.SaveChangesAsync();

    return Results.Created($"/api/matches/{match.id}/{nick}/{token}", match);

});

app.MapDelete("api/matches/{id}/{nick}/{token}", async (int id, string nick, string? token, FoottyContext db) => 
{
    bool access = db.User.Where(p => p.username == nick).Select(p => p.can_edit).First();
    string? key = db.User.Where(p => p.username == nick).Select(p => p.token).First();
    access = (token == key) && access;
    if (!access) {
        return Results.Unauthorized();
    }

    if (await db.Match.FindAsync(id) is footty.Models.Match match)
    {
        db.Match.Remove(match);
        await db.SaveChangesAsync();
        return Results.Ok(match);
    }

    return Results.NotFound();

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

app.MapPut("/api/teams/{id}/{name}/{nick}/{token}",
            async (int id, string name,
                     string nick, string? token, FoottyContext db) =>
{
    bool access = db.User.Where(p => p.username == nick).Select(p => p.can_edit).First();
    string? key = db.User.Where(p => p.username == nick).Select(p => p.token).First();
    access = (token == key) && access;
    if (!access) {
        return Results.Unauthorized();
    }
    var team = await db.Team.FindAsync(id);

    if (team is null) {
        Console.WriteLine("Match");
        return Results.NotFound();
    }

    team.name = name;

    await db.SaveChangesAsync();

    return Results.NoContent();
    
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

app.MapDelete("api/teams/{id}/{nick}/{token}", async (int id, string nick, string? token, FoottyContext db) => 
{
    bool access = db.User.Where(p => p.username == nick).Select(p => p.can_edit).First();
    string? key = db.User.Where(p => p.username == nick).Select(p => p.token).First();
    access = (token == key) && access;
    if (!access) {
        return Results.Unauthorized();
    }

    if (await db.Team.FindAsync(id) is footty.Models.Team team)
    {
        db.Team.Remove(team);
        await db.SaveChangesAsync();
        return Results.Ok(team);
    }

    return Results.NotFound();

});

app.MapGet("/api/players/{club}/{shirt}/{nick}/{token}", async (int club, string shirt, string nick, string? token, FoottyContext db) =>
{
    bool access = db.User.Where(p => p.username == nick).Select(p => p.can_edit).First();
    string? key = db.User.Where(p => p.username == nick).Select(p => p.token).First();
    access = (token == key) && access;
    if (!access) {
        return Results.Unauthorized();
    }
    return Results.Ok(await db.Player
                        .Include(p => p.team)
                        .Where(p => p.team!.id == club && p.shirt_number == shirt)
                        .ToListAsync());
    
});

app.MapPut("/api/players/{id}/{team}/{position}/{shirt}/{minutes}/{games}/{ass}/{goals}/{nick}/{token}",
            async (int id, int team, string? position, string? shirt, float minutes, int games, int ass, 
                    int goals, string nick, string? token, FoottyContext db) =>
{
    bool access = db.User.Where(p => p.username == nick).Select(p => p.can_edit).First();
    string? key = db.User.Where(p => p.username == nick).Select(p => p.token).First();
    access = (token == key) && access;
    if (!access) {
        return Results.Unauthorized();
    }
    var player = await db.Player.FindAsync(id);

    if (player is null) {
        return Results.NotFound();
    }

    var club = await db.Team.FindAsync(team);
    if  (club is null) {
        return Results.Unauthorized();
    }

    player.team = club;
    player.position = position;
    player.shirt_number = shirt;
    player.minutes_played = minutes;
    player.games_played = games;
    player.assists = ass;
    player.goals_scored = goals;

    await db.SaveChangesAsync();

    return Results.NoContent();
    
});

app.MapPost("/api/players/{team}/{position}/{shirt}/{minutes}/{games}/{ass}/{goals}/{nick}/{token}",
            async (int team, string? position, string? shirt, float minutes, int games, int ass, 
                    int goals, string nick, string? token, FoottyContext db) => 
{
    bool access = db.User.Where(p => p.username == nick).Select(p => p.can_edit).First();
    string? key = db.User.Where(p => p.username == nick).Select(p => p.token).First();
    access = (token == key) && access;
    if (!access) {
        return Results.Unauthorized();
    }

    var club = await db.Team.FindAsync(team);
    if  (club is null) {
        return Results.Unauthorized();
    }

    footty.Models.Player player = new footty.Models.Player{
        team = club,
        position = position,
        shirt_number = shirt,
        minutes_played = minutes,
        games_played = games,
        assists = ass,
        goals_scored = goals,
    };
    db.Player.Add(player);
    await db.SaveChangesAsync();

    return Results.Created($"/api/players/{team}/{player.shirt_number}/{nick}/{token}", player);
});

app.MapDelete("api/players/{id}/{nick}/{token}", async (int id, string nick, string? token, FoottyContext db) => 
{
    bool access = db.User.Where(p => p.username == nick).Select(p => p.can_edit).First();
    string? key = db.User.Where(p => p.username == nick).Select(p => p.token).First();
    access = (token == key) && access;
    if (!access) {
        return Results.Unauthorized();
    }

    if (await db.Player.FindAsync(id) is footty.Models.Player player)
    {
        db.Player.Remove(player);
        await db.SaveChangesAsync();
        return Results.Ok(player);
    }

    return Results.NotFound();

});

app.MapGet("/api/stadions/{city}/{nick}/{token}", async (String? city, string nick, string? token, FoottyContext db) =>
{
    bool access = db.User.Where(p => p.username == nick).Select(p => p.can_edit).First();
    string? key = db.User.Where(p => p.username == nick).Select(p => p.token).First();
    access = (token == key) && access;
    if (!access) {
        return Results.Unauthorized();
    }
    Console.WriteLine(city);
    return Results.Ok(await db.Stadium
                                .Include(s => s.team)
                                .Where(s => s.city == city+" ")
                                .ToListAsync());
    
});




app.Run();
