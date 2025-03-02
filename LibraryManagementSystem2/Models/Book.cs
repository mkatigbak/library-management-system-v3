using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem2.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}-\d{10}$")]
        public string ISBN { get; set; }

        [Range(1800, 2100)]
        public int PublicationYear { get; set; }

        public bool IsAvailable { get; set; }
    }
}
