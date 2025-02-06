using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Data;
using MovieApp.Web.Models;

namespace MovieApp.Web.ViewComponents;


public class GenreViewComponents : ViewComponent 
{
    public IViewComponentResult Invoke()
    {
        ViewBag.SelectedGenre = RouteData.Values["id"];
        
        return View(GenreRepository.Genres);
    }
}