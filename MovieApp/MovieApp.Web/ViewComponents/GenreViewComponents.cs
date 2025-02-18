using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Data;
using MovieApp.Web.Models;

namespace MovieApp.Web.ViewComponents;


public class GenreViewComponents : ViewComponent 
{
    private readonly MovieContext _context;

    public GenreViewComponents(MovieContext context)
    {
        _context = context;
    }
    public IViewComponentResult Invoke()
    {
        ViewBag.SelectedGenre = RouteData.Values["id"];
        
        return View(_context.Genres.ToList());
    }
}