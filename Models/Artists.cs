using System.ComponentModel.DataAnnotations;

namespace TunaPiano.Models;

public class Artists
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Bio { get; set; }
    public ICollection<Songs>? Song { get; set; }
}