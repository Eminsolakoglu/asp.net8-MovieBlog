using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Entity;

namespace MovieApp.Web.Data;

public class DataSeeding
{
    public static void Seed(MovieContext context)
    {
        // var scope = app.ApplicationServices.CreateScope();
        // var context = scope.ServiceProvider.GetService<MovieContext>();
        
        context.Database.Migrate();//dotnet ef database update yapmaya gerek yok bunun sayesinde
    
        var genres = new List<Genre>()
        {
            new Genre {Name = "Macera" ,
                Movies = new List<Movie>()
            {
                new Movie()
                {
                    Title = "Yeni macera filmi1",
                    Description = "Ünlü arkeolog Indiana Jones'un macera dolu bir keşif yolculuğu.",
                    ImageUrl = "indianajones.jpg",
                    
                },
                new Movie()
                {
                    Title = "Yeni macera filmi2",
                    Description = "Bir grup gencin, sihirli bir oyun sayesinde fantastik bir maceraya atılması.",
                    ImageUrl = "jumanji.jpeg",
                    
                },
            }
            
            },
            new Genre { Name = "Komedi" },
            new Genre { Name = "Romantik" },
            new Genre { Name = "Savaş" }
        };

        var movies = new List<Movie>()
        {
            new Movie()
            {
                 Title = "Indiana Jones: Kutsal Hazine Avcıları",
                Description = "Ünlü arkeolog Indiana Jones'un macera dolu bir keşif yolculuğu.",
                ImageUrl = "indianajones.jpg",
                Genre = genres[0]
            },
            new Movie()
            {
                 Title = "Jumanji: Welcome to the Jungle",
                Description = "Bir grup gencin, sihirli bir oyun sayesinde fantastik bir maceraya atılması.",
                ImageUrl = "jumanji.jpeg",
                Genre = genres[0]
            },
            new Movie()
            {
                 Title = "The Hangover",
                Description = "Bir grup arkadaşın çılgın bekarlığa veda partisi sonrası yaşadıkları komik olaylar.",
                ImageUrl = "hangover.jpeg",
                Genre = genres[1]// Komedi
            },
            new Movie()
            {
                 Title = "Superbad",
                Description = "İki lise öğrencisinin mezuniyet öncesi yaşadığı komik maceralar.",
                ImageUrl = "superbad.jpg",
                Genre = genres[1]// Komedi
            },
            new Movie()
            {
                 Title = "La La Land",
                Description =
                    "Los Angeles'ta yolları kesişen bir caz piyanisti ve bir aktris arasındaki romantik hikaye.",
                ImageUrl = "lalaland.jpg",
                Genre = genres[2]// Romantik
            },
            new Movie()
            {
                 Title = "Pride and Prejudice",
                Description = "Jane Austen'ın klasik aşk hikayesinin modern bir uyarlaması.",
                ImageUrl = "prideandprejudice.jpg",
                Genre = genres[2]// Romantik
            }

        };
        var users= new List<User>()
        {
            new User(){Username = "usera",Email = "usera@gmail.com",Password = "1234",ImageUrl = "batman.png"},
            new User(){Username = "userb",Email = "userb@gmail.com",Password = "1234",ImageUrl = "batman.png"},
            new User(){Username = "userc",Email = "userc@gmail.com",Password = "1234",ImageUrl = "batman.png",
                Person = new Person()
                {
                    Name = "Personel 1",
                    Biography = "Biography1",
                    Imdb = "1",
                    HomePage = "test",
                    PlaceOfBirth = "test",
                }
            },    
            new User(){Username = "userd",Email = "userd@gmail.com",Password = "1234",ImageUrl = "batman.png",
                Person = new Person()
                {
                    Name = "Personel 2",
                    Biography = "Biography2",
                    Imdb = "1",
                    HomePage = "test",
                    PlaceOfBirth = "test",
                }
            }
        };
        
        if (context.Database.GetPendingMigrations().Count()==0)
        {

             if (context.Genres.Count()==0)
             {
                 context.Genres.AddRange(genres);   
                 //context.SaveChanges();

             }
            if (context.Movies.Count()==0)
            {
                context.Movies.AddRange(movies);
                context.SaveChanges();
            }
            if (context.Users.Count()==0)
            {
                context.Users.AddRange(users);
                context.SaveChanges();

            }


           
            context.SaveChanges();
        }
    }
}