using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreFilms.Migrations
{
    /// <inheritdoc />
    public partial class CountView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "currency",
                table: "CinemaRooms",
                newName: "Currency");
            migrationBuilder.Sql(@"
CREATE VIEW [dbo].[FilmsWithCount]
AS
SELECT Id, Title,
(
	Select count(*) 
	from FilmsGender 
	Where FilmsId = Films.Id
) as CountGender,
(
	Select count(distinct CinemaId) 
	From CinemaRoomFilms 
	Inner Join CinemaRooms 
	ON CinemaRooms.Id = CinemaRoomFilms.cinemaRoomsId
	WHERE FilmsId = Films.Id
) as CountCinemas,
(
	Select count(*)
	From FilmsActors
	where FilmId = Films.Id
) as CountActors
FROM Films
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "CinemaRooms",
                newName: "currency");
            migrationBuilder.Sql(@"DROP VIEW [dbo].[FilmsWithCount]");
        }
    }
}
