using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreFilms.Migrations
{
    /// <inheritdoc />
    public partial class FilmsActors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmsActors",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsActors", x => new { x.FilmId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_FilmsActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmsActors_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmsActors_ActorId",
                table: "FilmsActors",
                column: "ActorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmsActors");
        }
    }
}
