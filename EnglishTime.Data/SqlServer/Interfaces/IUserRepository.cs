using System.Collections.Generic;

using EnglishTime.Data.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EnglishTime.Data.SqlServer.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetAll();
        User Get(int id);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        bool SaveChanges();
    }
}