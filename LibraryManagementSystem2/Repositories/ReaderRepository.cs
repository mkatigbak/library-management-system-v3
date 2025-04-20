using LibraryManagementSystem2.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem2.Repositories
{
    public class ReaderRepository
    {
        private readonly List<Reader> _readers = new();

        public IEnumerable<Reader> GetAll() => _readers;

        public Reader GetById(int id) => _readers.FirstOrDefault(r => r.Id == id);

        public void Add(Reader reader)
        {
            reader.Id = _readers.Count > 0 ? _readers.Max(r => r.Id) + 1 : 1;
            _readers.Add(reader);
        }

        public void Update(Reader reader)
        {
            var existing = GetById(reader.Id);
            if (existing != null)
            {
                existing.Name = reader.Name;
                existing.Email = reader.Email;
            }
        }

        public void Delete(int id)
        {
            var reader = GetById(id);
            if (reader != null)
            {
                _readers.Remove(reader);
            }
        }
    }
}
