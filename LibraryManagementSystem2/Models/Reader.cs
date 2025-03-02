using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem2.Models
{
    public class Reader
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
    }
}
