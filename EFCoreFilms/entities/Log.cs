using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreFilms.entities
{
    public class Log
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // no generate guid
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
