using Microsoft.AspNetCore.Mvc;
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
    public IActionResult List()
    {
        var filmListesi = new List<Movie>()
        {
            new Movie(){Title = "film1",
                Description = "desc1",
                Director = "nuribilgeceylan1",
                Actors = new string[] {"oyuncu1","oyuncu2"},
                ImageUrl = "batman.png"
            },
            new Movie(){Title = "film2",
                Description = "desc2",
                Director = "nuribilgeceylan2",
                Actors = new string[] {"oyuncu1","oyuncu2"},
                ImageUrl = "Jokerposter.jpg"
            },
            new Movie(){Title = "film3",
                Description = "desc3",
                Director = "nuribilgeceylan3",
                Actors = new string[] {"oyuncu1","oyuncu2"},
                ImageUrl = "moonlight.jpg"
            }
        };
        return View("Movies",filmListesi);
    }
    //localhost:5293/movies/details
    public string Details()
    {
        return "Film Detayı";
    }
}