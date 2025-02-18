using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Data;
using MovieApp.Web.Models;
using MovieApp.Web.Entity;

namespace MovieApp.Web.Controllers;

public class HomeController : Controller
{
    
    private readonly MovieContext _context;

    public HomeController(MovieContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        var model = new HomePageViewModel
        {
            PopularMovies = _context.Movies.ToList()
        };

        return View(model);
    }
    public IActionResult About()
    {
        return View();
    }
}