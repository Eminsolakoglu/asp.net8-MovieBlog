using System.ComponentModel.DataAnnotations;
using MovieApp.Web.Entity;

namespace MovieApp.Web.Models;

public class AdminMoviesViewModel
{
    public List<AdminMovieViewModel> Movies { get; set; }
}
public class AdminMovieViewModel
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public List<Genre> Genres { get; set; }
}

public class AdminCreateMovieModel
{
    [Display(Name = "Film adı")] 
    [Required(ErrorMessage = "Film Adı Girmelisiniz!")]
    [StringLength(50,MinimumLength = 3,ErrorMessage = "Film Adı için 3-50 karakter girmelisiniz")]
    public string Title { get; set; }
    [Display(Name = "Film açıklaması")]
    [Required(ErrorMessage = "Film açıklaması Girmelisiniz!")]
    [StringLength(3000,MinimumLength = 10,ErrorMessage = "Film açıklaması için 10-3000 karakter girmelisiniz")]
    public string Description { get; set; }
}
public class AdminEditMovieViewModel
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public List<Genre> SelectedGenres { get; set; }

}
