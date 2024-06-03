using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreFilms.Migrations
{
    /// <inheritdoc />
    public partial class fieldCurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "currency",
                table: "CinemaRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "currency",
                value: "");

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "currency",
                value: "");

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "currency",
                value: "");

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "currency",
                value: "");

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "currency",
                value: "");

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "currency",
                value: "");

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 7,
                column: "currency",
                value: "");

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 8,
                column: "currency",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "currency",
                table: "CinemaRooms");
        }
    }
}
