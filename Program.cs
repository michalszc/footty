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

    if (!isLogged && path != "/User/Login" && path != "/User/Logout")
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

app.Run();
