using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resto.Service;
using System.Reflection;
using Resto.Data;

namespace Resto.Client
{
    public  class Program
    {
       
        static void Main(string[] args)
        {
            var uploadManager = new UploadManager();
            //uploadManager.UploadRestaurantData();


            
            IKernel kernal = new StandardKernel();
            kernal.Load(Assembly.GetExecutingAssembly());

            kernal.Bind(typeof(IRepository<>)).To(typeof(Repository<>));

            kernal.Bind<IUserService>().To<UserService>();
            kernal.Bind<IRestaurantService>().To<RestaurantService>();



            kernal.Bind<IService>().To<ServiceClass>();
            var service = kernal.Get<ServiceBase>();
            service.ImplementServiceMember();


            var restoService = kernal.Get<RestaurantServiceBase>();
            restoService.GetItems();
            

            Console.ReadLine();

        }

    }
}
