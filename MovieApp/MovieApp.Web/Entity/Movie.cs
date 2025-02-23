

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MovieApp.Web.Entity;
public class Movie
{
    // Primary Key => Id,  <TypeName>Id
    public int  MovieId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
    
    public string ImageUrl { get; set; }
  
    public List<Genre> Genres { get; set; }
    
    
}