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
                MovieId = 1, Title = "Indiana Jones: Kutsal Hazine Avcıları",
                Description = "Ünlü arkeolog Indiana Jones'un macera dolu bir keşif yolculuğu.",
                Director = "Steven Spielberg",
                Actors = new string[] {"Harrison Ford", "Karen Allen", "Paul Freeman"},
                ImageUrl = "indianajones.jpg",
                GenreId = 1 // Macera
            },
            new Movie(){
                MovieId = 2, Title = "Jumanji: Welcome to the Jungle",
                Description = "Bir grup gencin, sihirli bir oyun sayesinde fantastik bir maceraya atılması.",
                Director = "Jake Kasdan",
                Actors = new string[] {"Dwayne Johnson", "Kevin Hart", "Jack Black"},
                ImageUrl = "jumanji.jpeg",
                GenreId = 1 // Macera
            },
            new Movie(){
                MovieId = 3, Title = "The Hangover",
                Description = "Bir grup arkadaşın çılgın bekarlığa veda partisi sonrası yaşadıkları komik olaylar.",
                Director = "Todd Phillips",
                Actors = new string[] {"Bradley Cooper", "Ed Helms", "Zach Galifianakis"},
                ImageUrl = "hangover.jpeg",
                GenreId = 2 // Komedi
            },
            new Movie(){
                MovieId = 4, Title = "Superbad",
                Description = "İki lise öğrencisinin mezuniyet öncesi yaşadığı komik maceralar.",
                Director = "Greg Mottola",
                Actors = new string[] {"Jonah Hill", "Michael Cera", "Emma Stone"},
                ImageUrl = "superbad.jpg",
                GenreId = 2 // Komedi
            },
            new Movie(){
                MovieId = 5, Title = "La La Land",
                Description = "Los Angeles'ta yolları kesişen bir caz piyanisti ve bir aktris arasındaki romantik hikaye.",
                Director = "Damien Chazelle",
                Actors = new string[] {"Ryan Gosling", "Emma Stone", "John Legend"},
                ImageUrl = "lalaland.jpg",
                GenreId = 3 // Romantik
            },
            new Movie(){
                MovieId = 6, Title = "Pride and Prejudice",
                Description = "Jane Austen'ın klasik aşk hikayesinin modern bir uyarlaması.",
                Director = "Joe Wright",
                Actors = new string[] {"Keira Knightley", "Matthew Macfadyen", "Rosamund Pike"},
                ImageUrl = "prideandprejudice.jpg",
                GenreId = 3 // Romantik
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