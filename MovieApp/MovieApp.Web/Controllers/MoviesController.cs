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
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Genres = new SelectList(_context.Genres.ToList(),"GenreId","Name");

        return View();
    }
    [HttpPost]
    public IActionResult Create(Movie m)
    {
        if (ModelState.IsValid)
        {
            //MovieRepository.Add(m);
            _context.Movies.Add(m);
            _context.SaveChanges();
            TempData["Message"] = $"{m.Title} isimli film eklendi.";
            return RedirectToAction("List");
        }
        ViewBag.Genres = new SelectList(_context.Genres.ToList(),"GenreId","Name");

        return View();

    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        ViewBag.Genres = new SelectList(_context.Genres.ToList(),"GenreId","Name");
        return View(_context.Movies.Find(id));
    }
    [HttpPost]
    public IActionResult Edit(Movie m)
    {
        if (ModelState.IsValid)
        {
            // MovieRepository.Edit(m);
            _context.Movies.Update(m);
            _context.SaveChanges();
            
            // /movies/details/id
            return RedirectToAction("Details","Movies",new {id=m.MovieId});

        }
        ViewBag.Genres = new SelectList(_context.Genres.ToList(),"GenreId","Name");

        return View(m);
    }
    [HttpPost]
    public IActionResult Delete(int MovieId,string Title)
    {
        var entity = _context.Movies.Find(MovieId);
        _context.Movies.Remove(entity);
        _context.SaveChanges();
        TempData["Message"] = $"{Title} isimli film silindi.";
        return RedirectToAction("List");
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}  