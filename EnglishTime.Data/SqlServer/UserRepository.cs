using System;
using System.Collections.Generic;
using System.Linq;

using EnglishTime.Data.Model;
using EnglishTime.Data.SqlServer.Interfaces;

namespace EnglishTime.Data.SqlServer
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext _context;
        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public ICollection<User> GetAll()
        {
            return _context.User.ToList();
        }

        public User Get(int id)
        {
            return _context.User.SingleOrDefault(p => p.Id == id);
        }

        public User GetByEmail(string email)
        {
            return _context.User.SingleOrDefault(p => p.Email.Equals(email));
        }

        public void Create(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.User.Add(user);
        }

        public void Update(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.User.Update(user);
        }

        public void Delete(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.User.Remove(user);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}