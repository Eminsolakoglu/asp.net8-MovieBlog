using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp.Web.Data;
using MovieApp.Web.Models;
using MovieApp.Web.Entity;

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
        ViewBag.Genres = new SelectList(GenreRepository.Genres,"GenreId","Name");

        return View();
    }
    [HttpPost]
    public IActionResult Create(Movie m)
    {
        if (ModelState.IsValid)
        {
            MovieRepository.Add(m);
            TempData["Message"] = $"{m.Title} isimli film eklendi.";
            return RedirectToAction("List");
        }
        ViewBag.Genres = new SelectList(GenreRepository.Genres,"GenreId","Name");

        return View();

    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        ViewBag.Genres = new SelectList(GenreRepository.Genres,"GenreId","Name");
        return View(MovieRepository.GetById(id));
    }
    [HttpPost]
    public IActionResult Edit(Movie m)
    {
        if (ModelState.IsValid)
        {
            MovieRepository.Edit(m);
            // /movies/details/id
            return RedirectToAction("Details","Movies",new {id=m.MovieId});

        }
        ViewBag.Genres = new SelectList(GenreRepository.Genres,"GenreId","Name");

        return View(m);
    }
    [HttpPost]
    public IActionResult Delete(int MovieId,string Title)
    {
        MovieRepository.Delete(MovieId);
        TempData["Message"] = $"{Title} isimli film silindi.";
        return RedirectToAction("List");
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}  