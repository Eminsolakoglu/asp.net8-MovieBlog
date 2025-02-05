using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Models;

namespace MovieApp.Web.ViewComponents;


public class GenreViewComponents : ViewComponent 
{
    public IViewComponentResult Invoke()
    {
        var turListesi = new List<Genre>()
        {
            new Genre { Name = "Macera" },
            new Genre { Name = "Komedi" },
            new Genre { Name = "Romantik" },
            new Genre { Name = "Savaş" }
        };
        return View(turListesi);
    }
}