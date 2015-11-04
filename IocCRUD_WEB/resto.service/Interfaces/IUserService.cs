using Resto.Core;
using Resto.Core.Data;
using Resto.Data;
using System.Collections.Generic;
using System.Linq;

namespace Resto.Service
{
    public interface IUserService
    {
        IQueryable<User> GetUsers();
        User GetUser(long id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);

    }
}
