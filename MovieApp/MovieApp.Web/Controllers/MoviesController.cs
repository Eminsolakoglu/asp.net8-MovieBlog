using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Data;
using MovieApp.Web.Models;

namespace MovieApp.Web.Controllers;

public class MoviesController : Controller
{
    // action
    //localhost:5293/movies
    [HttpGet]
    public IActionResult Index()
    {
        return  View();
    }
    //localhost:5293/movies/list
    [HttpGet]
    public IActionResult List(int? id,string q)
    {

      //  var kelime = HttpContext.Request.Query["q"].ToString();
        
        var movies = MovieRepository.Movies;
        if (id != null)
        {
            movies = movies.Where(m => m.GenreId == id).ToList();
        }

        if (!string.IsNullOrEmpty(q))
        {
            movies = movies.Where(i => 
                i.Title.ToLower().Contains(q.ToLower()) ||
                i.Description.ToLower().Contains(q.ToLower()) ).ToList();
        }
        
        var model = new MoviesViewModel()
        {
            Movies = movies
            
        };
        return View("Movies", model);
    }
    //localhost:5293/movies/details
    [HttpGet]
    public IActionResult Details(int id)
    {
        
        return View(MovieRepository.GetById((id)));
    } 
    [HttpGet]
    public IActionResult Create()
    {
        
        return View();
    }
    [HttpPost]
    public IActionResult Create(Movie m)
    {
        MovieRepository.Add(m);
        return RedirectToAction("List");
    }
}