using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Entity;

namespace MovieApp.Web.Data;

public class DataSeeding
{
    public static void Seed(MovieContext context)
    {
        // var scope = app.ApplicationServices.CreateScope();
        // var context = scope.ServiceProvider.GetService<MovieContext>();
        
        context.Database.Migrate();

        if (context.Database.GetPendingMigrations().Count()==0)
        {

            if (context.Movies.Count()==0)
            {
                context.Movies.AddRange(new List<Movie>()
                        {
                            new Movie(){
                                MovieId = 1, Title = "Indiana Jones: Kutsal Hazine Avcıları",
                                Description = "Ünlü arkeolog Indiana Jones'un macera dolu bir keşif yolculuğu.",
                                Director = "Steven Spielberg",
                                ImageUrl = "indianajones.jpg",
                                GenreId = 1 // Macera
                            },
                            new Movie(){
                                MovieId = 2, Title = "Jumanji: Welcome to the Jungle",
                                Description = "Bir grup gencin, sihirli bir oyun sayesinde fantastik bir maceraya atılması.",
                                Director = "Jake Kasdan",
                                ImageUrl = "jumanji.jpeg",
                                GenreId = 1 // Macera
                            },
                            new Movie(){
                                MovieId = 3, Title = "The Hangover",
                                Description = "Bir grup arkadaşın çılgın bekarlığa veda partisi sonrası yaşadıkları komik olaylar.",
                                Director = "Todd Phillips",
                                ImageUrl = "hangover.jpeg",
                                GenreId = 2 // Komedi
                            },
                            new Movie(){
                                MovieId = 4, Title = "Superbad",
                                Description = "İki lise öğrencisinin mezuniyet öncesi yaşadığı komik maceralar.",
                                Director = "Greg Mottola",
                                ImageUrl = "superbad.jpg",
                                GenreId = 2 // Komedi
                            },
                            new Movie(){
                                MovieId = 5, Title = "La La Land",
                                Description = "Los Angeles'ta yolları kesişen bir caz piyanisti ve bir aktris arasındaki romantik hikaye.",
                                Director = "Damien Chazelle",
                                ImageUrl = "lalaland.jpg",
                                GenreId = 3 // Romantik
                            },
                            new Movie(){
                                MovieId = 6, Title = "Pride and Prejudice",
                                Description = "Jane Austen'ın klasik aşk hikayesinin modern bir uyarlaması.",
                                Director = "Joe Wright",
                                ImageUrl = "prideandprejudice.jpg",
                                GenreId = 3 // Romantik
                            }

                        }
                    );
            }

            if (context.Genres.Count()==0)
            {
                context.Genres.AddRange(
                        new List<Genre>()
                        {
                            new Genre { GenreId = 1,Name="Macera" },
                            new Genre { GenreId = 2,Name = "Komedi" },
                            new Genre { GenreId = 3,Name = "Romantik" },
                            new Genre { GenreId = 4,Name = "Savaş" }

                        }
                    );
                
            }
            context.SaveChanges();
        }
    }
}