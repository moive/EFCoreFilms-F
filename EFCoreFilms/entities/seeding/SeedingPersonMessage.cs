using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EFCoreFilms.entities.seeding
{
    public static class SeedingPersonMessage
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var felipe = new Person() { Id = 1, Name = "Feliple" };
            var claudia = new Person() { Id = 2, Name = "Claudia" };

            var message1 = new Message() { Id = 1, Content = "Hello Claudia!", SenderId = felipe.Id, RecipientId = claudia.Id };
            var message2 = new Message() { Id = 2, Content = "Hello Felipe. How are you?", SenderId = claudia.Id, RecipientId = felipe.Id };
            var message3 = new Message() { Id = 3, Content = "Very good, and you?", SenderId = felipe.Id, RecipientId = claudia.Id };
            var message4 = new Message() { Id = 4, Content = "Nice :)", SenderId = claudia.Id, RecipientId = felipe.Id };


            modelBuilder.Entity<Person>().HasData(felipe, claudia);
            modelBuilder.Entity<Message>().HasData(message1, message2, message3, message4);
        }
    }
}
