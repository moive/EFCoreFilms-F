using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreFilms.Migrations
{
    /// <inheritdoc />
    public partial class FilmsGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmsGender",
                columns: table => new
                {
                    FilmsId = table.Column<int>(type: "int", nullable: false),
                    GendersIdentifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsGender", x => new { x.FilmsId, x.GendersIdentifier });
                    table.ForeignKey(
                        name: "FK_FilmsGender_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmsGender_Genders_GendersIdentifier",
                        column: x => x.GendersIdentifier,
                        principalTable: "Genders",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmsGender_GendersIdentifier",
                table: "FilmsGender",
                column: "GendersIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmsGender");
        }
    }
}
