using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Data;
using MovieApp.Web.Models;

namespace MovieApp.Web.Controllers;

public class MoviesController : Controller
{
    // action
    //localhost:5293/movies
    public IActionResult Index()
    {
        return  View();
    }
    //localhost:5293/movies/list
    public IActionResult List()
    {
        var model = new MoviesViewModel()
        {
            Movies = MovieRepository.Movies
        };
        return View("Movies", model);
    }
    //localhost:5293/movies/details
    public IActionResult Details(int id)
    {
        
        return View(MovieRepository.GetById((id)));
    }
}