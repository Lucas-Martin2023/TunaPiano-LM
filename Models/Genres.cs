using System.ComponentModel.DataAnnotations;

namespace TunaPiano.Models
{
    public class Genres
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Songs>? Song { get; set; }
    }
}