using System.Collections.Generic;

using EnglishTime.Data.Model;

namespace EnglishTime.Core.Provider.Interfaces
{
    public interface IUserProvider
    {
        ICollection<User> GetAllUsers();
        User GetUser(int id);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
    }
}