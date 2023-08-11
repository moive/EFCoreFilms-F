using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreFilms.Migrations
{
    /// <inheritdoc />
    public partial class FilmsCinemaRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CinemaRoomFilms",
                columns: table => new
                {
                    FilmsId = table.Column<int>(type: "int", nullable: false),
                    cinemaRoomsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaRoomFilms", x => new { x.FilmsId, x.cinemaRoomsId });
                    table.ForeignKey(
                        name: "FK_CinemaRoomFilms_CinemaRooms_cinemaRoomsId",
                        column: x => x.cinemaRoomsId,
                        principalTable: "CinemaRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CinemaRoomFilms_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaRoomFilms_cinemaRoomsId",
                table: "CinemaRoomFilms",
                column: "cinemaRoomsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaRoomFilms");
        }
    }
}
