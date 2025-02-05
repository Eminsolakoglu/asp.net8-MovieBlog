using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Models;

namespace MovieApp.Web.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        string filmB = "filmbasliği";
        string filmAciklama = "filmin aciklamasi";
        string filmyonetmeni = "filmin yonetmeni";
        string[] oyuncular = { "oyuncu1", "oyuncu2", "oyuncu3" };

        var m = new Movie();

        m.Title = filmB;
        m.Director = filmyonetmeni;
        m.Description = filmAciklama;
        m.Actors = oyuncular;
        m.ImageUrl = "batman.png";

        return View(m);
    }
    public IActionResult About()
    {
        return View();
    }
}