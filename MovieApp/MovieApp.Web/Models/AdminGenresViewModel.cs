using MovieApp.Web.Entity;

namespace MovieApp.Web.Models;

public class AdminGenresViewModel
{
    public List<AdminGenreViewModel> Genres { get; set; }
}

public class AdminGenreViewModel
{
    public int GenreId { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }
}