using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreFilms.Migrations
{
    /// <inheritdoc />
    public partial class WeCannotDeleteCinemaWithMovieTheaters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaRooms_Cinemas_CinemaId",
                table: "CinemaRooms");

            migrationBuilder.UpdateData(
                table: "CinemaOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 9, 27, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinemaOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 9, 27, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaRooms_Cinemas_CinemaId",
                table: "CinemaRooms",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaRooms_Cinemas_CinemaId",
                table: "CinemaRooms");

            migrationBuilder.UpdateData(
                table: "CinemaOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 9, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 8, 31, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinemaOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 8, 31, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaRooms_Cinemas_CinemaId",
                table: "CinemaRooms",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
