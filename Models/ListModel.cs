using System.ComponentModel.DataAnnotations;

namespace DotnetMvc.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
}