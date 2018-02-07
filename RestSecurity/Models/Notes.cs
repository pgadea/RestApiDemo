using System.ComponentModel.DataAnnotations;

namespace RestSecurity.Models
{
    public class Notes
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string NotesTitle { get; set; }

        [StringLength(1000)]
        public string NotesDescription { get; set; }

        public string UserId { get; set; }
    }
}