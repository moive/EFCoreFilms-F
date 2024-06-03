using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreFilms.Migrations
{
    /// <inheritdoc />
    public partial class exampleConvertion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CinemaType",
                table: "CinemaRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "TwoDimensions",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CinemaType",
                value: "TwoDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CinemaType",
                value: "ThreeDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CinemaType",
                value: "TwoDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "CinemaType",
                value: "ThreeDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "CinemaType",
                value: "TwoDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "CinemaType",
                value: "ThreeDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 7,
                column: "CinemaType",
                value: "CxC");

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 8,
                column: "CinemaType",
                value: "TwoDimensions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CinemaType",
                table: "CinemaRooms",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "TwoDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CinemaType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CinemaType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CinemaType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "CinemaType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "CinemaType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "CinemaType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 7,
                column: "CinemaType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 8,
                column: "CinemaType",
                value: 1);
        }
    }
}
