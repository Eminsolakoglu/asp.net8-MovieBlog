using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Data;
using MovieApp.Web.Models;
using MovieApp.Web.Entity;

namespace MovieApp.Web.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        var model = new HomePageViewModel
        {
            PopularMovies = MovieRepository.Movies
        };

        return View(model);
    }
    public IActionResult About()
    {
        return View();
    }
}