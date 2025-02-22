

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MovieApp.Web.Entity;
public class Movie
{
    // Primary Key => Id,  <TypeName>Id
    public int  MovieId { get; set; }
    [Required]
    public string Title { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    
    public string ImageUrl { get; set; }
    [Required] 
    public Genre Genre { get; set; }//navigation property
    public int GenreId { get; set; }
    
    
}