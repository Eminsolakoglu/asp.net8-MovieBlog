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
            new Genre { Name = "Savaş" },
            new Genre { Name = "Oscar Aldı" }
            
        };

        var movies = new List<Movie>()
        {
            new Movie()
            {
                 Title = "Indiana Jones: Kutsal Hazine Avcıları",
                Description = "Ünlü arkeolog Indiana Jones'un macera dolu bir keşif yolculuğu.",
                ImageUrl = "indianajones.jpg",
                Genres = new List<Genre>(){genres[0],new Genre(){Name="Yeni tür"},genres[4]}
            },
            new Movie()
            {
                 Title = "Jumanji: Welcome to the Jungle",
                Description = "Bir grup gencin, sihirli bir oyun sayesinde fantastik bir maceraya atılması.",
                ImageUrl = "jumanji.jpeg",
                Genres = new List<Genre>(){genres[0],genres[4]}
            },
            new Movie()
            {
                 Title = "The Hangover",
                Description = "Bir grup arkadaşın çılgın bekarlığa veda partisi sonrası yaşadıkları komik olaylar.",
                ImageUrl = "hangover.jpeg",
                Genres = new List<Genre>(){genres[4],genres[1]}
            },
            new Movie()
            {
                 Title = "Superbad",
                Description = "İki lise öğrencisinin mezuniyet öncesi yaşadığı komik maceralar.",
                ImageUrl = "superbad.jpg",
                Genres = new List<Genre>(){genres[4],genres[1]}
            },
            new Movie()
            {
                 Title = "La La Land",
                Description =
                    "Los Angeles'ta yolları kesişen bir caz piyanisti ve bir aktris arasındaki romantik hikaye.",
                ImageUrl = "lalaland.jpg",
                Genres = new List<Genre>(){genres[4],genres[2]}
            },
            new Movie()
            {
                 Title = "Pride and Prejudice",
                Description = "Jane Austen'ın klasik aşk hikayesinin modern bir uyarlaması.",
                ImageUrl = "prideandprejudice.jpg",
                Genres = new List<Genre>(){genres[4],genres[2]}
            }

        };
        var users= new List<User>()
        {
            new User(){Username = "usera",Email = "usera@gmail.com",Password = "1234",ImageUrl = "batman.png"},
            new User(){Username = "userb",Email = "userb@gmail.com",Password = "1234",ImageUrl = "batman.png"},
            new User(){Username = "userc",Email = "userc@gmail.com",Password = "1234",ImageUrl = "batman.png"},    
            new User(){Username = "userd",Email = "userd@gmail.com",Password = "1234",ImageUrl = "batman.png"}
        };

        var people = new List<Person>()
        {
            new Person()
            {
                Name = "Personel 1",
                Biography = "Biography1",
                Imdb = "1",
                HomePage = "test",
                PlaceOfBirth = "test",
                User = users[0]
            },
            new Person()
            {
                Name = "Personel 2",
                Biography = "Biography2",
                Imdb = "1",
                HomePage = "test",
                PlaceOfBirth = "test",
                User = users[1]

            }
        };

        var crews = new List<Crew>()
        {
            new Crew() { Movie = movies[0], Person = people[0], Job = "Yönetmen" },
            new Crew() { Movie = movies[0], Person = people[1], Job = "Yönetmen Yard" },
        };
        var casts = new List<Cast>()
        {
            new Cast() { Movie = movies[0], Person = people[0], Name = "Oyuncu Adı1", Character = "Karakter1", },
            new Cast() { Movie = movies[0], Person = people[1], Name = "Oyuncu Adı2", Character = "Karakter2", }
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
            }
            if (context.Users.Count()==0)
            {
                context.Users.AddRange(users);
            }
            if (context.Persons.Count()==0)
            {
                context.Persons.AddRange(people);
            }
            if (context.Crews.Count()==0)
            {
                context.Crews.AddRange(crews); 
            }
            if (context.Casts.Count()==0)
            {
                context.Casts.AddRange(casts);
            }


           
            context.SaveChanges();
        }
    }
}