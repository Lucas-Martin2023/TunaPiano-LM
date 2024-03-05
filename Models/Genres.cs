using System.ComponentModel.DataAnnotations;

namespace TunaPiano.Models;

public class Genres
{
    public int Id { get; set; }
    [Required]
    public string Description { get; set; }
}