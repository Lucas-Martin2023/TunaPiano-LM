using System.ComponentModel.DataAnnotations;

namespace TunaPiano.Models
{
    public class Songs
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Artist_Id { get; set; }
        public string Album { get; set; }
        public int Length { get; set; }
        public ICollection<Genres> Genre { get; set; }
    }
}