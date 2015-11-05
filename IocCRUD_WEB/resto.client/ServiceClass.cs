using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resto.Core.Data;
using Resto.Service;

namespace Resto.Client
{

    public interface IService
    {
        void PrintMessage();
    }

    public class ServiceClass : IService
    {

        public void PrintMessage()
        {
           Console.WriteLine("This is test message from DI IOC");
        }

    }

    public class ServiceBase
    {
        private IService service = null;
        public ServiceBase(IService service)
        {
            this.service = service;
        }

        public void ImplementServiceMember()
        {
            service.PrintMessage();
        }
    }



    public class RestaurantServiceBase
    {
        private IRestaurantService service;
        public RestaurantServiceBase(IRestaurantService serivce)
        {
            this.service = serivce;
        }

        public void GetItems()
        {
            var items = service.GetItems();
            foreach (var restaurant in items)
            {
                Console.WriteLine("Name {0} ", restaurant.name);
            }


        }

    }

}
