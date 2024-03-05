using Microsoft.EntityFrameworkCore;
using TunaPiano.Models;
using System.Runtime.CompilerServices;

public class TunaPianoDbContext : DbContext
{

    public DbSet<Artists> Artists { get; set; }
    public DbSet<Genres> Genres { get; set; }
    public DbSet<Song_genre> Song_genre { get; set; }
    public DbSet<Songs> Songs { get; set; }

    public TunaPianoDbContext(DbContextOptions<TunaPianoDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Artists>().HasData(new Artists[]
        {
        new Artists {Id = 1, Name = "Eminem", Age = 51, Bio = "From Detroit and eats mom's spaghetti"},
        new Artists {Id = 2, Name = "Led Zeppelin", Age = 56, Bio = "Loves to rock"},
        new Artists {Id = 3, Name = "Kenny Rogers", Age = 81, Bio = "Old guy that has a gambling problem"},
        new Artists {Id = 4, Name = "Carly Rae Jepsen", Age = 38, Bio = "Needs someone to call her soon"},
        });

        modelBuilder.Entity<Songs>().HasData(new Songs[]
        {
        new Songs {Id = 1, Title = "Mom's Spaghetti", Artist_Id = 1, Album = "Spaghetti", Length = 5},
        new Songs {Id = 2, Title = "Whole Lotta Love", Artist_Id = 2, Album = "THE Rock Store", Length = 4},
        new Songs {Id = 3, Title = "The Gambler", Artist_Id = 3, Album = "Country Roads and Stuff", Length = 3},
        new Songs {Id = 4, Title = "Call Me Maybe", Artist_Id = 4, Album = "I'm too old to be acting like a teen", Length = 2}
        });

        modelBuilder.Entity<Genres>().HasData(new Genres[]
        {
        new Genres {Id = 1, Description = "Rap"},
        new Genres {Id = 2, Description = "Rock"},
        new Genres {Id = 3, Description = "Country"},
        new Genres {Id = 4, Description = "Pop"}
        });

        modelBuilder.Entity<Song_genre>().HasData(new Song_genre[]
        {
        new Song_genre {Id = 1, Song_id = 1, Genre_id = 1},
        new Song_genre {Id = 2, Song_id = 2, Genre_id = 2},
        new Song_genre {Id = 3, Song_id = 3, Genre_id = 3},
        new Song_genre {Id = 4, Song_id = 4, Genre_id = 4}
        });
    }
}