using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreFilms.Migrations
{
    /// <inheritdoc />
    public partial class CinemaIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaOffers_Cinemas_CinemaId",
                table: "CinemaOffers");

            migrationBuilder.DropIndex(
                name: "IX_CinemaOffers_CinemaId",
                table: "CinemaOffers");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "CinemaOffers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaOffers_CinemaId",
                table: "CinemaOffers",
                column: "CinemaId",
                unique: true,
                filter: "[CinemaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaOffers_Cinemas_CinemaId",
                table: "CinemaOffers",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaOffers_Cinemas_CinemaId",
                table: "CinemaOffers");

            migrationBuilder.DropIndex(
                name: "IX_CinemaOffers_CinemaId",
                table: "CinemaOffers");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "CinemaOffers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CinemaOffers_CinemaId",
                table: "CinemaOffers",
                column: "CinemaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaOffers_Cinemas_CinemaId",
                table: "CinemaOffers",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
