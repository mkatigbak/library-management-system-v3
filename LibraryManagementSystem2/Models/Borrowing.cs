using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem2.Models
{
    public class Borrowing
    {
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int ReaderId { get; set; }

        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        public decimal OverdueCharge { get; set; }
    }
}
