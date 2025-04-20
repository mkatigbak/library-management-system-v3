using LibraryManagementSystem2.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem2.Repositories
{
    public class UserRepository
    {
        private readonly List<User> _users = new();

        public IEnumerable<User> GetAll() => _users;

        public User GetByUsername(string username) => _users.FirstOrDefault(u => u.Username == username);

        public void Add(User user)
        {
            user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
        }

        public bool ValidateUser(string username, string password)
        {
            return _users.Any(u => u.Username == username && u.Password == password);
        }
    }
}