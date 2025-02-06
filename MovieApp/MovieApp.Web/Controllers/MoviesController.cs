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
    public IActionResult List(int? id)
    {
        var movies = MovieRepository.Movies;
        if (id != null)
        {
            movies = movies.Where(m => m.GenreId == id).ToList();
        }
            
            
            
        var model = new MoviesViewModel()
        {
            Movies = movies
            
        };
        return View("Movies", model);
    }
    //localhost:5293/movies/details
    public IActionResult Details(int id)
    {
        
        return View(MovieRepository.GetById((id)));
    }
}