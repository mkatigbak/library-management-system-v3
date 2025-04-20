using LibraryManagementSystem2.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem2.Repositories
{
    public class BookRepository
    {
        private readonly List<Book> _books = new();

        public IEnumerable<Book> GetAll() => _books;

        public Book GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void Add(Book book)
        {
            book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
        }

        public void Update(Book book)
        {
            var existing = GetById(book.Id);
            if (existing != null)
            {
                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.IsAvailable = book.IsAvailable;
            }
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }
    }
}
