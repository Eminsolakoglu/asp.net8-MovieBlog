using MovieApp.Web.Models;

namespace MovieApp.Web.Data;

public class MovieRepository
{
    private static readonly List<Movie> _movies = null;

    static MovieRepository()
    {
        _movies = new List<Movie>()
        {
            new Movie(){
                MovieId = 1,Title = "film1",
                Description = "desc1",
                Director = "nuribilgeceylan1",
                Actors = new string[] {"oyuncu1","oyuncu2"},
                ImageUrl = "batman.png"
            },
            new Movie(){
                MovieId = 2,Title = "film2",
                Description = "desc2",
                Director = "nuribilgeceylan2",
                Actors = new string[] {"oyuncu1","oyuncu2"},
                ImageUrl = "Jokerposter.jpg"
            },
            new Movie(){
                MovieId = 3,Title = "film3",
                Description = "desc3",
                Director = "nuribilgeceylan3",
                Actors = new string[] {"oyuncu1","oyuncu2"},
                ImageUrl = "moonlight.jpg"
            },
            new Movie(){
                MovieId =4,Title = "film1",
                Description = "desc1",
                Director = "nuribilgeceylan1",
                Actors = new string[] {"oyuncu1","oyuncu2"},
                ImageUrl = "batman.png"
            },
            new Movie(){
                MovieId = 5,Title = "film2",
                Description = "desc2",
                Director = "nuribilgeceylan2",
                Actors = new string[] {"oyuncu1","oyuncu2"},
                ImageUrl = "Jokerposter.jpg"
            },
            new Movie(){
                MovieId = 6,Title = "film3",
                Description = "desc3",
                Director = "nuribilgeceylan3",
                Actors = new string[] {"oyuncu1","oyuncu2"},
                ImageUrl = "moonlight.jpg"
            }
        };
    }

    public static List<Movie> Movies
    {
        get
        {
            return _movies;
        }   
    }

    public static void Add(Movie movie)
    {
        _movies.Add(movie);
    }

    public static Movie GetById(int id)
    {
        return _movies.FirstOrDefault(m => m.MovieId== id);
    }
}