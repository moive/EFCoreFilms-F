namespace EFCoreFilms.entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int SenderId { get; set; }
        public Person Sender { get; set; }
        public int RecipientId { get; set; }
        public Person Recipient { get; set; }
    }
}
