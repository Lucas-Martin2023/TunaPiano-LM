﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TunaPiano.Migrations
{
    [DbContext(typeof(TunaPianoDbContext))]
    [Migration("20240311012818_thirdCreate")]
    partial class thirdCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GenresSongs", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int>("SongId")
                        .HasColumnType("integer");

                    b.HasKey("GenreId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("GenresSongs");
                });

            modelBuilder.Entity("TunaPiano.Models.Artists", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 51,
                            Bio = "From Detroit and eats mom's spaghetti",
                            Name = "Eminem"
                        },
                        new
                        {
                            Id = 2,
                            Age = 56,
                            Bio = "Loves to rock",
                            Name = "Led Zeppelin"
                        },
                        new
                        {
                            Id = 3,
                            Age = 81,
                            Bio = "Old guy that has a gambling problem",
                            Name = "Kenny Rogers"
                        },
                        new
                        {
                            Id = 4,
                            Age = 38,
                            Bio = "Needs someone to call her soon",
                            Name = "Carly Rae Jepsen"
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.Genres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Rap"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Rock"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Country"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Pop"
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.Song_genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Genre_id")
                        .HasColumnType("integer");

                    b.Property<int>("Song_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Song_genre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Genre_id = 1,
                            Song_id = 1
                        },
                        new
                        {
                            Id = 2,
                            Genre_id = 2,
                            Song_id = 2
                        },
                        new
                        {
                            Id = 3,
                            Genre_id = 3,
                            Song_id = 3
                        },
                        new
                        {
                            Id = 4,
                            Genre_id = 4,
                            Song_id = 4
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.Songs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Artist_Id")
                        .HasColumnType("integer");

                    b.Property<int?>("ArtistsId")
                        .HasColumnType("integer");

                    b.Property<int>("Length")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtistsId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Album = "Spaghetti",
                            Artist_Id = 1,
                            Length = 5,
                            Title = "Mom's Spaghetti"
                        },
                        new
                        {
                            Id = 2,
                            Album = "THE Rock Store",
                            Artist_Id = 2,
                            Length = 4,
                            Title = "Whole Lotta Love"
                        },
                        new
                        {
                            Id = 3,
                            Album = "Country Roads and Stuff",
                            Artist_Id = 3,
                            Length = 3,
                            Title = "The Gambler"
                        },
                        new
                        {
                            Id = 4,
                            Album = "I'm too old to be acting like a teen",
                            Artist_Id = 4,
                            Length = 2,
                            Title = "Call Me Maybe"
                        });
                });

            modelBuilder.Entity("GenresSongs", b =>
                {
                    b.HasOne("TunaPiano.Models.Genres", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TunaPiano.Models.Songs", null)
                        .WithMany()
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TunaPiano.Models.Songs", b =>
                {
                    b.HasOne("TunaPiano.Models.Artists", null)
                        .WithMany("Song")
                        .HasForeignKey("ArtistsId");
                });

            modelBuilder.Entity("TunaPiano.Models.Artists", b =>
                {
                    b.Navigation("Song");
                });
#pragma warning restore 612, 618
        }
    }
}
