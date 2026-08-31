using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreFilms.entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [InverseProperty("Sender")]
        public List<Message> SendMessages { get; set; }
        [InverseProperty("Recipient")]
        public List<Message> ReceivedMessages { get; set; }
    }
}
