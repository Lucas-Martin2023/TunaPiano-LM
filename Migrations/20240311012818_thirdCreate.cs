using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPiano.Migrations
{
    public partial class thirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Songs",
                newName: "ArtistsId");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                newName: "IX_Songs_ArtistsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistsId",
                table: "Songs",
                column: "ArtistsId",
                principalTable: "Artists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistsId",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "ArtistsId",
                table: "Songs",
                newName: "ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_ArtistsId",
                table: "Songs",
                newName: "IX_Songs_ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");
        }
    }
}
