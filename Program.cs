using TunaPiano.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<TunaPianoDbContext>(builder.Configuration["TunaPianoDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// SONGS
// Create a Song
app.MapPost("/api/songs", (TunaPianoDbContext db, Songs newSong) =>
{
    db.Songs.Add(newSong);
    db.SaveChanges();
    return Results.Created($"/api/songs/{newSong.Id}", newSong);
});

// Delete a single Song
app.MapDelete("/api/songs/{id}", (TunaPianoDbContext db, int id) =>
{
    Songs songs = db.Songs.SingleOrDefault(songs => songs.Id == id);
    if (songs == null)
    {
        return Results.NotFound();
    }
    db.Songs.Remove(songs);
    db.SaveChanges();
    return Results.NoContent();
});

// Update a Song
app.MapPut("/api/songs/{id}", (TunaPianoDbContext db, int id, Songs songs) =>
{
    Songs songToUpdate = db.Songs.SingleOrDefault(songs => songs.Id == id);
    if (songToUpdate == null)
    {
        return Results.NotFound();
    }
    songToUpdate.Title = songs.Title;
    songToUpdate.Artist_Id = songs.Artist_Id;
    songToUpdate.Album = songs.Album;
    songToUpdate.Length = songs.Length;

    db.SaveChanges();
    return Results.NoContent();
});

// Gets list of all Songs
app.MapGet("/api/songs", (TunaPianoDbContext db) =>
{
    return db.Songs.ToList();
});

// Details View of single song and associated genres and artist details
app.MapGet("/api/songs/{id}", (TunaPianoDbContext db, int id) =>
{
    var song = db.Songs
        .Include(s => s.Genre)
        .FirstOrDefault(sg => sg.Id == id);

    var artist = from artists in db.Artists
                 join songs in db.Songs on artists.Id equals songs.Artist_Id
                 select artists;

    var songDetails = new { song, artist };

    return songDetails;
});



// ARTISTS
// Create a Artist
app.MapPost("/api/artists", (TunaPianoDbContext db, Artists newArtist) =>
{
    db.Artists.Add(newArtist);
    db.SaveChanges();
    return Results.Created($"/api/artists/{newArtist.Id}", newArtist);
});

// Delete a single Artist
app.MapDelete("/api/artists/{id}", (TunaPianoDbContext db, int id) =>
{
    Artists artists = db.Artists.SingleOrDefault(artists => artists.Id == id);
    if (artists == null)
    {
        return Results.NotFound();
    }
    db.Artists.Remove(artists);
    db.SaveChanges();
    return Results.NoContent();
});

// Update a Artist
app.MapPut("/api/artists/{id}", (TunaPianoDbContext db, int id, Artists artists) =>
{
    Artists artistToUpdate = db.Artists.SingleOrDefault(artists => artists.Id == id);
    if (artistToUpdate == null)
    {
        return Results.NotFound();
    }
    artistToUpdate.Name = artists.Name;
    artistToUpdate.Age = artists.Age;
    artistToUpdate.Bio = artists.Bio;

    db.SaveChanges();
    return Results.NoContent();
});

// Gets list of all Artists
app.MapGet("/api/artists", (TunaPianoDbContext db) =>
{
    return db.Artists.ToList();
});

// Gets Details view of single Artist and the songs associated with them
app.MapGet("/api/artists/{id}", (TunaPianoDbContext db, int id) =>
{
    var singleArtistWithSongs = from artist in db.Artists
                         join song in db.Songs on artist.Id equals song.Artist_Id
                         where artist.Id == id
                         select new { artist, song };
    return singleArtistWithSongs;
});



// GENRES
// Create a Genre
app.MapPost("/api/genres", (TunaPianoDbContext db, Genres newGenre) =>
{
    db.Genres.Add(newGenre);
    db.SaveChanges();
    return Results.Created($"/api/genres/{newGenre.Id}", newGenre);
});

// Delete a single Genre
app.MapDelete("/api/genres/{id}", (TunaPianoDbContext db, int id) =>
{
    Genres genres = db.Genres.SingleOrDefault(genres => genres.Id == id);
    if (genres == null)
    {
        return Results.NotFound();
    }
    db.Genres.Remove(genres);
    db.SaveChanges();
    return Results.NoContent();
});

// Update a Genre
app.MapPut("/api/genres/{id}", (TunaPianoDbContext db, int id, Genres genres) =>
{
    Genres genreToUpdate = db.Genres.SingleOrDefault(genres => genres.Id == id);
    if (genreToUpdate == null)
    {
        return Results.NotFound();
    }
    genreToUpdate.Description = genres.Description;

    db.SaveChanges();
    return Results.NoContent();
});

// Gets list of all Genre
app.MapGet("/api/genres", (TunaPianoDbContext db) =>
{
    return db.Genres.ToList();
});

// Gets Details view of a single Genre and the songs associated with it
app.MapGet("/api/genres/{id}", (TunaPianoDbContext db, int id) =>
{
    var singleGenreWithSongs = db.Genres.Include(g => g.Song).FirstOrDefault(g => g.Id == id);
    return singleGenreWithSongs;
});

app.Run();
