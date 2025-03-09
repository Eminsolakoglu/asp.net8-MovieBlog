using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Data;
using MovieApp.Web.Models;
using MovieApp.Web.Entity;

namespace MovieApp.Web.Controllers;

public class MoviesController : Controller
{
    private readonly MovieContext _context;

    public MoviesController(MovieContext context)
    {
        _context = context;
    }
    
    
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
        
        // var movies = MovieRepository.Movies;
        var movies = _context.Movies.AsQueryable();
        if (id != null)
        {
            movies = movies
                .Include(m=>m.Genres).
                Where(m => m.Genres.Any(g=>g.GenreId==id));
        }

        if (!string.IsNullOrEmpty(q))
        {
            movies = movies.Where(i => 
                i.Title.ToLower().Contains(q.ToLower()) ||
                i.Description.ToLower().Contains(q.ToLower()) );
        }
        
        var model = new MoviesViewModel()
        {
            Movies = movies.ToList()
            
        };
        return View("Movies", model);
    }
    //localhost:5293/movies/details
    [HttpGet]
    public IActionResult Details(int id)
    {
        
        return View(_context.Movies.Find(id));
    } 
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}  