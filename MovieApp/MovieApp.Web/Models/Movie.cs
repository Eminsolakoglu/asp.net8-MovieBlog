using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Models;

public class Movie
{
    public int  MovieId { get; set; }
    
    [DisplayName("Başlık")]
   [Required(ErrorMessage = "film basligi eklemelisiniz")]
    [StringLength(50,MinimumLength =5,ErrorMessage = "film basliği 5-50 karakter olmalı")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "film description eklemelisiniz")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "film director eklemelisiniz")]
    public string Director { get; set; }
    
    public string[] Actors { get; set; } = Array.Empty<string>();
    
    [Required(ErrorMessage = "film gere eklemelisiniz")]
    public int? GenreId { get; set; }
    
    [Required(ErrorMessage = "film image eklemelisiniz")]
    public string ImageUrl { get; set; }
}