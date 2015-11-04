using Resto.Core.Data;
using Resto.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Service
{
    public class UserService : IUserService
    {
        private IRepository<User> userRepository;
        private IRepository<UserProfile> userProfileRepository;

        public UserService(IRepository<User> userRepository, IRepository<UserProfile> userProfileRepository)
        {
            this.userRepository = userRepository;
            this.userProfileRepository = userProfileRepository;
        }


        public void DeleteUser(User user)
        {
            userProfileRepository.Delete(user.UserProfile);
            userRepository.Delete(user);
        }

        public User GetUser(long id)
        {
            return userRepository.GetById(id);
        }

        public IQueryable<User> GetUsers()
        {
            return userRepository.Table;
        }

        public void InsertUser(User user)
        {
            userRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }
    }
}
