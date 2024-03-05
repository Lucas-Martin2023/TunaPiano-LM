using System.ComponentModel.DataAnnotations;

namespace TunaPiano.Models;

public class Song_genre
{
    public int Id { get; set; }
    [Required]
    public int Song_id { get; set; }
    public int Genre_id { get; set; }
}