using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Entity;

namespace MovieApp.Web.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options):base(options)
    {
        
    }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Person> Persons  { get; set; }
    public DbSet<Crew> Crews  { get; set; }
    public DbSet<Cast> Casts  { get; set; }
    

  /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
        optionsBuilder.UseSqlite("Data Source=movies.db");
    }*/

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
      base.OnModelCreating(modelBuilder); //Temel sınıfın yapılandırılmasını uygular ve güncellemelere uyum sağlar 
      modelBuilder.Entity<Movie>().Property(b => b.Title).IsRequired();
      modelBuilder.Entity<Movie>().Property(b => b.Title).HasMaxLength(500);
      
      modelBuilder.Entity<Genre>().Property(b => b.Name).IsRequired();
      modelBuilder.Entity<Genre>().Property(b => b.Name).HasMaxLength(50);

  }
}