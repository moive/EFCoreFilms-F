﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreFilms.Migrations
{
    /// <inheritdoc />
    public partial class DataTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Bio", "BirthDate", "Name" },
                values: new object[,]
                {
                    { 1, "Thomas Stanley Holland (Kingston upon Thames, Londres; 1 de junio de 1996), conocido simplemente como Tom Holland, es un actor, actor de voz y bailarín británico.", new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom Holland" },
                    { 2, "Samuel Leroy Jackson (Washington D. C., 21 de diciembre de 1948), conocido como Samuel L. Jackson, es un actor y productor de cine, televisión y teatro estadounidense. Ha sido candidato al premio Óscar, a los Globos de Oro y al Premio del Sindicato de Actores, así como ganador de un BAFTA al mejor actor de reparto.", new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samuel L. Jackson" },
                    { 3, "Robert John Downey Jr. (Nueva York, 4 de abril de 1965) es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York.", new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Downey Jr." },
                    { 4, null, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris Evans" },
                    { 5, null, new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dwayne Johnson" },
                    { 6, null, new DateTime(2000, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auli'i Cravalho" },
                    { 7, null, new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scarlett Johansson" },
                    { 8, null, new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keanu Reeves" }
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.9388777 18.4839233)"), "Agora Mall" },
                    { 2, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.911582 18.482455)"), "Sambil" },
                    { 3, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.856309 18.506662)"), "Megacentro" },
                    { 4, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.939248 18.469649)"), "Acropolis" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "OnBillboard", "ReleaseDate", "Title", "posterURL" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers", "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg" },
                    { 2, false, new DateTime(2017, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coco", "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg" },
                    { 3, false, new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: No way home", "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg" },
                    { 4, false, new DateTime(2019, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: Far From Home", "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg" },
                    { 5, true, new DateTime(2100, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix Resurrections", "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Identifier", "Name" },
                values: new object[,]
                {
                    { 1, "Acción" },
                    { 2, "Animación" },
                    { 3, "Comedia" },
                    { 4, "Ciencia ficción" },
                    { 5, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "CinemaOffers",
                columns: new[] { "Id", "CinemaId", "DiscountPercentage", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, 10m, new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 4, 15m, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "CinemaRooms",
                columns: new[] { "Id", "CinemaId", "CinemaType", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1, 220m },
                    { 2, 1, 2, 320m },
                    { 3, 2, 1, 200m },
                    { 4, 2, 2, 290m },
                    { 5, 3, 1, 250m },
                    { 6, 3, 2, 330m },
                    { 7, 3, 3, 450m },
                    { 8, 4, 1, 250m }
                });

            migrationBuilder.InsertData(
                table: "FilmsActors",
                columns: new[] { "ActorId", "FilmId", "Character", "Order" },
                values: new object[,]
                {
                    { 3, 1, "Iron Man", 2 },
                    { 4, 1, "Capitán América", 1 },
                    { 7, 1, "Black Widow", 3 },
                    { 1, 3, "Peter Parker", 1 },
                    { 1, 4, "Peter Parker", 1 },
                    { 2, 4, "Samuel L. Jackson", 2 },
                    { 8, 5, "Neo", 1 }
                });

            migrationBuilder.InsertData(
                table: "FilmsGender",
                columns: new[] { "FilmsId", "GendersIdentifier" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 3 },
                    { 4, 4 },
                    { 5, 1 },
                    { 5, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "CinemaRoomFilms",
                columns: new[] { "FilmsId", "cinemaRoomsId" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 4 },
                    { 5, 5 },
                    { 5, 6 },
                    { 5, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CinemaOffers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CinemaOffers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CinemaRoomFilms",
                keyColumns: new[] { "FilmsId", "cinemaRoomsId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "CinemaRoomFilms",
                keyColumns: new[] { "FilmsId", "cinemaRoomsId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "CinemaRoomFilms",
                keyColumns: new[] { "FilmsId", "cinemaRoomsId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "CinemaRoomFilms",
                keyColumns: new[] { "FilmsId", "cinemaRoomsId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "CinemaRoomFilms",
                keyColumns: new[] { "FilmsId", "cinemaRoomsId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "CinemaRoomFilms",
                keyColumns: new[] { "FilmsId", "cinemaRoomsId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "CinemaRoomFilms",
                keyColumns: new[] { "FilmsId", "cinemaRoomsId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FilmsActors",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "FilmsActors",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "FilmsActors",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "FilmsActors",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "FilmsActors",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "FilmsActors",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "FilmsActors",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "FilmsGender",
                keyColumns: new[] { "FilmsId", "GendersIdentifier" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "FilmsGender",
                keyColumns: new[] { "FilmsId", "GendersIdentifier" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "FilmsGender",
                keyColumns: new[] { "FilmsId", "GendersIdentifier" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "FilmsGender",
                keyColumns: new[] { "FilmsId", "GendersIdentifier" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "FilmsGender",
                keyColumns: new[] { "FilmsId", "GendersIdentifier" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "FilmsGender",
                keyColumns: new[] { "FilmsId", "GendersIdentifier" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "FilmsGender",
                keyColumns: new[] { "FilmsId", "GendersIdentifier" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "FilmsGender",
                keyColumns: new[] { "FilmsId", "GendersIdentifier" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "FilmsGender",
                keyColumns: new[] { "FilmsId", "GendersIdentifier" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "FilmsGender",
                keyColumns: new[] { "FilmsId", "GendersIdentifier" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "FilmsGender",
                keyColumns: new[] { "FilmsId", "GendersIdentifier" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "FilmsGender",
                keyColumns: new[] { "FilmsId", "GendersIdentifier" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CinemaRooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Identifier",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Identifier",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Identifier",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Identifier",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Identifier",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
