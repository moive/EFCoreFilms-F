using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreFilms.Migrations
{
    /// <inheritdoc />
    public partial class IndexNameFilter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Genders_Name",
                table: "Genders");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_Name",
                table: "Genders",
                column: "Name",
                unique: true,
                filter: "IsRemoved = 'false'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Genders_Name",
                table: "Genders");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_Name",
                table: "Genders",
                column: "Name",
                unique: true);
        }
    }
}
