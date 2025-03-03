using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Data;
using MovieApp.Web.Models;

namespace MovieApp.Web.Controllers;

public class AdminController : Controller
{
    private readonly MovieContext _context;

    public AdminController(MovieContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult MovieList()
    {
        return View(new AdminMoviesViewModel()
        {
            Movies = _context.Movies
                .Include(m=>m.Genres)
                .Select(m=>new AdminMovieViewModel
                {
                    MovieId=m.MovieId,
                    Title=m.Title,
                    ImageUrl=m.ImageUrl,
                    Genres=m.Genres.ToList() 
                        
                }).ToList()
        });
    }
}