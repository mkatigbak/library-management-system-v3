using LibraryManagementSystem2.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem2.Repositories
{
    public class BorrowingRepository
    {
        private readonly List<Borrowing> _borrowings = new();

        public IEnumerable<Borrowing> GetAll() => _borrowings;

        public Borrowing GetById(int id) => _borrowings.FirstOrDefault(b => b.Id == id);

        public void Add(Borrowing borrowing)
        {
            borrowing.Id = _borrowings.Count > 0 ? _borrowings.Max(b => b.Id) + 1 : 1;
            _borrowings.Add(borrowing);
        }

        public void Update(Borrowing borrowing)
        {
            var existing = GetById(borrowing.Id);
            if (existing != null)
            {
                existing.BookId = borrowing.BookId;
                existing.ReaderId = borrowing.ReaderId;
                existing.BorrowDate = borrowing.BorrowDate;
                existing.ReturnDate = borrowing.ReturnDate;
            }
        }

        public void Delete(int id)
        {
            var borrowing = GetById(id);
            if (borrowing != null)
            {
                _borrowings.Remove(borrowing);
            }
        }
    }
}
