using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Data;
using MovieApp.Web.Entity;
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

    public IActionResult MovieUpdate(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var entity = _context.Movies
            .Select(m => new AdminEditMovieViewModel
            {
                MovieId = m.MovieId,
                Title = m.Title,
                ImageUrl = m.ImageUrl,
                Description = m.Description,
                SelectedGenres = m.Genres
            }).FirstOrDefault(m => m.MovieId == id);

        ViewBag.Genres = _context.Genres.ToList();

        if (entity == null)
        {
            return NotFound();
        }

        return View(entity);
    }

    [HttpPost]
    public IActionResult MovieUpdate(AdminEditMovieViewModel model, int[] genreIds)
    {
        var entity = _context.Movies.Include("Genres").FirstOrDefault(m => m.MovieId == model.MovieId);
        if (entity == null)
        {
            return NotFound();
        }

        entity.Title = model.Title;
        entity.Description = model.Description;
        entity.ImageUrl = model.ImageUrl;
        entity.Genres = genreIds.Select(id => _context.Genres.FirstOrDefault(i => i.GenreId == id)).ToList();

        _context.SaveChanges();

        return RedirectToAction("MovieList");
    }

    public IActionResult MovieList()
    {
        return View(new AdminMoviesViewModel()
        {
            Movies = _context.Movies
                .Include(m => m.Genres)
                .Select(m => new AdminMovieViewModel
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    ImageUrl = m.ImageUrl,
                    Genres = m.Genres.ToList()
                }).ToList()
        });
    }

    public IActionResult GenreList()
    {
        return View(new AdminGenresViewModel
        {
            Genres = _context.Genres.Select(g => new AdminGenreViewModel
            {
                GenreId = g.GenreId,
                Name = g.Name,
                Count = g.Movies.Count
            }).ToList()
        });
    }

    public IActionResult GenreUpdate(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var entity = _context
            .Genres
            .Select(g => new AdminGenreEditViewModel
            {
                GenreId = g.GenreId,
                Name = g.Name,
                Movies = g.Movies.Select(i => new AdminMovieViewModel
                {
                    MovieId = i.MovieId,
                    Title = i.Title,
                    ImageUrl = i.ImageUrl
                }).ToList()
            })
            .FirstOrDefault(g => g.GenreId == id);
        if (entity == null)
        {
            return NotFound();
        }

        return View(entity);
    }

    [HttpPost]
    public IActionResult GenreUpdate(AdminGenreEditViewModel model, int[] movieIds)
    {
        var entity = _context.Genres.Include("Movies").FirstOrDefault(i => i.GenreId == model.GenreId);
        if (entity == null)
        {
            return NotFound();
        }

        entity.Name = model.Name;
        foreach (var id in movieIds)
        {
            entity.Movies.Remove(entity.Movies.FirstOrDefault(m => m.MovieId == id));
        }
        _context.SaveChanges();
        return RedirectToAction("GenreList");
    }
}