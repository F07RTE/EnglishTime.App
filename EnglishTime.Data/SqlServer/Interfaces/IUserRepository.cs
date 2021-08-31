using System.Collections.Generic;

using EnglishTime.Data.Model;

namespace EnglishTime.Data.SqlServer.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetAll();
        User Get(int id);
        User GetByEmail(string email);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        bool SaveChanges();
    }
}