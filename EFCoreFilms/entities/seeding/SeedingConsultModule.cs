using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using NetTopologySuite;

namespace EFCoreFilms.entities.seeding
{
    public static class SeedingConsultModule
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var acción = new Gender { Identifier = 1, Name = "Acción" };
            var animación = new Gender {Identifier = 2, Name = "Animación" };
            var comedia = new Gender {Identifier = 3, Name = "Comedia" };
            var cienciaFicción = new Gender {Identifier = 4, Name = "Ciencia ficción" };
            var drama = new Gender {Identifier = 5, Name = "Drama" };

            modelBuilder.Entity<Gender>().HasData(acción, animación, comedia, cienciaFicción, drama);

            var tomHolland = new Actor() { Id = 1, Name = "Tom Holland", BirthDate = new DateTime(1996, 6, 1), Bio = "Thomas Stanley Holland (Kingston upon Thames, Londres; 1 de junio de 1996), conocido simplemente como Tom Holland, es un actor, actor de voz y bailarín británico." };
            var samuelJackson = new Actor() { Id = 2, Name = "Samuel L. Jackson", BirthDate = new DateTime(1948, 12, 21), Bio = "Samuel Leroy Jackson (Washington D. C., 21 de diciembre de 1948), conocido como Samuel L. Jackson, es un actor y productor de cine, televisión y teatro estadounidense. Ha sido candidato al premio Óscar, a los Globos de Oro y al Premio del Sindicato de Actores, así como ganador de un BAFTA al mejor actor de reparto." };
            var robertDowney = new Actor() { Id = 3, Name = "Robert Downey Jr.", BirthDate = new DateTime(1965, 4, 4), Bio = "Robert John Downey Jr. (Nueva York, 4 de abril de 1965) es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York." };
            var chrisEvans = new Actor() { Id = 4, Name = "Chris Evans", BirthDate = new DateTime(1981, 06, 13) };
            var laRoca = new Actor() { Id = 5, Name = "Dwayne Johnson", BirthDate = new DateTime(1972, 5, 2) };
            var auliCravalho = new Actor() { Id = 6, Name = "Auli'i Cravalho", BirthDate = new DateTime(2000, 11, 22) };
            var scarlettJohansson = new Actor() { Id = 7, Name = "Scarlett Johansson", BirthDate = new DateTime(1984, 11, 22) };
            var keanuReeves = new Actor() { Id = 8, Name = "Keanu Reeves", BirthDate = new DateTime(1964, 9, 2) };

            modelBuilder.Entity<Actor>().HasData(tomHolland, samuelJackson,
                            robertDowney, chrisEvans, laRoca, auliCravalho, scarlettJohansson, keanuReeves);
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var agora = new Cinema() { Id = 1, Name = "Agora Mall", Location = geometryFactory.CreatePoint(new Coordinate(-69.9388777, 18.4839233)) };
            var sambil = new Cinema() { Id = 2, Name = "Sambil", Location = geometryFactory.CreatePoint(new Coordinate(-69.911582, 18.482455)) };
            var megacentro = new Cinema() { Id = 3, Name = "Megacentro", Location = geometryFactory.CreatePoint(new Coordinate(-69.856309, 18.506662)) };
            var acropolis = new Cinema() { Id = 4, Name = "Acropolis", Location = geometryFactory.CreatePoint(new Coordinate(-69.939248, 18.469649)) };

            var agoraCineOferta = new CinemaOffer { Id = 1, CinemaId = agora.Id, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(7), DiscountPercentage = 10 };

            var salaDeCine2DAgora = new CinemaRoom()
            {
                Id = 1,
                CinemaId = agora.Id,
                Price = 220,
                CinemaType = CinemaType.TwoDimensions
            };
            var salaDeCine3DAgora = new CinemaRoom()
            {
                Id = 2,
                CinemaId = agora.Id,
                Price = 320,
                CinemaType = CinemaType.ThreeDimensions
            };

            var salaDeCine2DSambil = new CinemaRoom()
            {
                Id = 3,
                CinemaId = sambil.Id,
                Price = 200,
                CinemaType= CinemaType.TwoDimensions
            };
            var salaDeCine3DSambil = new CinemaRoom()
            {
                Id = 4,
                CinemaId = sambil.Id,
                Price = 290,
                CinemaType = CinemaType.ThreeDimensions
            };


            var salaDeCine2DMegacentro = new CinemaRoom()
            {
                Id = 5,
                CinemaId = megacentro.Id,
                Price = 250,
                CinemaType = CinemaType.TwoDimensions
            };
            var salaDeCine3DMegacentro = new CinemaRoom()
            {
                Id = 6,
                CinemaId = megacentro.Id,
                Price= 330,
                CinemaType = CinemaType.ThreeDimensions
            };
            var salaDeCineCXCMegacentro = new CinemaRoom()
            {
                Id = 7,
                CinemaId = megacentro.Id,
                Price = 450,
                CinemaType = CinemaType.CxC
            };

            var salaDeCine2DAcropolis = new CinemaRoom()
            {
                Id = 8,
                CinemaId = acropolis.Id,
                Price = 250,
                CinemaType = CinemaType.TwoDimensions
            };

            var acropolisCineOferta = new CinemaOffer { Id = 2, CinemaId = acropolis.Id, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(5), DiscountPercentage = 15 };

            modelBuilder.Entity<Cinema>().HasData(acropolis, sambil, megacentro, agora);
            modelBuilder.Entity<CinemaOffer>().HasData(acropolisCineOferta, agoraCineOferta);
            modelBuilder.Entity<CinemaRoom>().HasData(salaDeCine2DMegacentro, salaDeCine3DMegacentro, salaDeCineCXCMegacentro, salaDeCine2DAcropolis, salaDeCine2DAgora, salaDeCine3DAgora, salaDeCine2DSambil, salaDeCine3DSambil);


            var avengers = new Films()
            {
                Id = 1,
                Title = "Avengers",
                OnBillboard = false,
                ReleaseDate = new DateTime(2012, 4, 11),
                posterURL = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
            };

            var entidadGeneroPelicula = "FilmsGender";
            var generoIdPropiedad = "GendersIdentifier";
            var peliculaIdPropiedad = "FilmsId";

            var entidadSalaDeCinePelicula = "CinemaRoomFilms";
            var salaDeCineIdPropiedad = "cinemaRoomsId";

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
                new Dictionary<string, object> { [generoIdPropiedad] = acción.Identifier, [peliculaIdPropiedad] = avengers.Id },
                new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Identifier, [peliculaIdPropiedad] = avengers.Id }
            );

            var coco = new Films()
            {
                Id = 2,
                Title = "Coco",
                OnBillboard = false,
                ReleaseDate = new DateTime(2017, 11, 22),
                posterURL = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg"
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = animación.Identifier, [peliculaIdPropiedad] = coco.Id }
           );

            var noWayHome = new Films()
            {
                Id = 3,
                Title = "Spider-Man: No way home",
                OnBillboard = false,
                ReleaseDate = new DateTime(2021, 12, 17),
                posterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Identifier, [peliculaIdPropiedad] = noWayHome.Id },
               new Dictionary<string, object> { [generoIdPropiedad] = acción.Identifier, [peliculaIdPropiedad] = noWayHome.Id },
               new Dictionary<string, object> { [generoIdPropiedad] = comedia.Identifier, [peliculaIdPropiedad] = noWayHome.Id }
           );

            var farFromHome = new Films()
            {
                Id = 4,
                Title = "Spider-Man: Far From Home",
                OnBillboard = false,
                ReleaseDate = new DateTime(2019, 7, 2),
                posterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Identifier, [peliculaIdPropiedad] = farFromHome.Id },
               new Dictionary<string, object> { [generoIdPropiedad] = acción.Identifier, [peliculaIdPropiedad] = farFromHome.Id },
               new Dictionary<string, object> { [generoIdPropiedad] = comedia.Identifier, [peliculaIdPropiedad] = farFromHome.Id }
           );

            // Para matrix pongo la fecha en el futuro

            var theMatrixResurrections = new Films()
            {
                Id = 5,
                Title = "The Matrix Resurrections",
                OnBillboard = true,
                ReleaseDate = new DateTime(2100, 1, 1),
                posterURL = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
              new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Identifier, [peliculaIdPropiedad] = theMatrixResurrections.Id },
              new Dictionary<string, object> { [generoIdPropiedad] = acción.Identifier, [peliculaIdPropiedad] = theMatrixResurrections.Id },
              new Dictionary<string, object> { [generoIdPropiedad] = drama.Identifier, [peliculaIdPropiedad] = theMatrixResurrections.Id }
          );

            modelBuilder.Entity(entidadSalaDeCinePelicula).HasData(
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine2DSambil.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine3DSambil.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine2DAgora.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine3DAgora.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine2DMegacentro.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine3DMegacentro.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCineCXCMegacentro.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id }
         );


            var keanuReevesMatrix = new FilmActor
            {
                ActorId = keanuReeves.Id,
                FilmId = theMatrixResurrections.Id,
                Order = 1,
                Character = "Neo"
            };

            var avengersChrisEvans = new FilmActor
            {
                ActorId = chrisEvans.Id,
                FilmId = avengers.Id,
                Order = 1,
                Character = "Capitán América"
            };

            var avengersRobertDowney = new FilmActor
            {
                ActorId = robertDowney.Id,
                FilmId = avengers.Id,
                Order = 2,
                Character = "Iron Man"
            };

            var avengersScarlettJohansson = new FilmActor
            {
                ActorId = scarlettJohansson.Id,
                FilmId = avengers.Id,
                Order = 3,
                Character = "Black Widow"
            };

            var tomHollandFFH = new FilmActor
            {
                ActorId = tomHolland.Id,
                FilmId = farFromHome.Id,
                Order = 1,
                Character = "Peter Parker"
            };

            var tomHollandNWH = new FilmActor
            {
                ActorId = tomHolland.Id,
                FilmId = noWayHome.Id,
                Order = 1,
                Character = "Peter Parker"
            };

            var samuelJacksonFFH = new FilmActor
            {
                ActorId = samuelJackson.Id,
                FilmId = farFromHome.Id,
                Order = 2,
                Character = "Samuel L. Jackson"
            };

            modelBuilder.Entity<Films>().HasData(avengers, coco, noWayHome, farFromHome, theMatrixResurrections);
            modelBuilder.Entity<FilmActor>().HasData(samuelJacksonFFH, tomHollandFFH, tomHollandNWH, avengersRobertDowney, avengersScarlettJohansson,
                avengersChrisEvans, keanuReevesMatrix);

        }
    }
}
