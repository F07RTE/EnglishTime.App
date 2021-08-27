using System.Collections.Generic;

using EnglishTime.Core.Provider.Interfaces;
using EnglishTime.Data.SqlServer.Interfaces;
using EnglishTime.Data.Model;

namespace EnglishTime.Core.Provider
{
    public class UserProvider : IUserProvider
    {
        private IUserRepository _userRepository;

        public UserProvider(
            IUserRepository userRepository
        )
        {
            _userRepository = userRepository;
        }

        public ICollection<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUser(int id)
        {
            return _userRepository.Get(id);
        }

        public bool IsEmailAlreadyRegistered(string email)
        {
            if(_userRepository.GetByEmail(email) == null)
                return false;
            
            return true;
        }

        public bool CreateUser(User user)
        {   
            _userRepository.Create(user);
            return _userRepository.SaveChanges();
        }

        public bool UpdateUser(User user)
        {   
            _userRepository.Update(user);
            return _userRepository.SaveChanges();
        }

        public bool DeleteUser(User user)
        {   
            _userRepository.Delete(user);
            return _userRepository.SaveChanges();
        }
    }
}
