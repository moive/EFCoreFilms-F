﻿using Microsoft.EntityFrameworkCore;

namespace EFCoreFilms.entities
{
    public class Films
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool OnBillboard { get; set; }
        public DateTime ReleaseDate { get; set; }
        //[Unicode(false)]
        public string posterURL { get; set; }
        public List<Gender> Genders { get; set; }
        public List<CinemaRoom> cinemaRooms { get; set; }
        public List<FilmActor> FilmsActors { get; set; }
    }
}
