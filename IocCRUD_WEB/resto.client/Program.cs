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
        private IRestaurantService restoService;

        public Program(IRestaurantService resService)
        {
            this.restoService = restoService;
        }

        public void outputRestaurant()
        {
            var r = restoService.GetItems().ToList();

            Console.WriteLine("Executed Restaurant Services");
        }

        static void Main(string[] args)
        {
            IKernel kernal = new StandardKernel();
            kernal.Load(Assembly.GetExecutingAssembly());

            kernal.Bind(typeof(IRepository<>)).To(typeof(MongoDbContext<>));

            kernal.Bind<IUserService>().To<UserService>();
            kernal.Bind<IRestaurantService>().To<RestaurantService>();

            var restoService = kernal.Get<IRestaurantService>();

            var prog = new Program(restoService);
            prog.outputRestaurant();

           // var instance = kernal.Get<sourav>();
           // instance.Attack();
            Console.ReadLine();

        }

        ///// <summary>
        ///// Load your modules or register your services here!
        ///// </summary>
        ///// <param name="kernel">The kernel.</param>
        //private static void RegisterServices(IKernel kernel)
        //{
        //    kernel.Bind<IDbContext>().To<IocDbContext>().InRequestScope();
        //    kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InRequestScope();
        //    kernel.Bind<IUserService>().To<UserService>();
        //}
    }
}
