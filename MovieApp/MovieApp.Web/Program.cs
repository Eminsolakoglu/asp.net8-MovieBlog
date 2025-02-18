using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews(); // veya builder.Services.AddControllersWithViews();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
/*
app.MapControllerRoute("movieList", "movies/list", new { controller = "Movies", action = "List" }, null, null);

app.MapControllerRoute("movieDetails", "movies/details", new { controller = "Movies", action = "Details" }, null, null);

app.MapControllerRoute("home", "", new { controller = "Home", action = "Index" }, null, null);

app.MapControllerRoute("about", "about", new { controller = "Home", action = "About" }, null, null);

*/


    app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}", null, null, null);
    app.UseStaticFiles();//wwwroot klasörünü kullanıma açıyoruz.

app.Run();