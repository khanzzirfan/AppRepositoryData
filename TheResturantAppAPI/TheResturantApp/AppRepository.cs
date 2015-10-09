using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using TheResturantApp.Models;
using Microsoft.AspNet.Identity.EntityFramework;


namespace TheResturantApp
{
   public class AppRepository : IDisposable
    {
        private TRAContext _ctx;
        private UserManager<IdentityUser> _userManager;

         public AppRepository()
        {
            _ctx = new TRAContext();
            _userManager=new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

         public async Task<IdentityResult> RegisterUser(UserLogin userModel)
         {
             var user = new IdentityUser
             {
                 UserName = userModel.UserName,
             };

             var result = await _userManager.CreateAsync(user, userModel.Password);
             return result;
         }

         public async Task<IdentityUser> FindUser(string userName, string password)
         {
             IdentityUser user = await _userManager.FindAsync(userName, password);
             return user;
         }


        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}
