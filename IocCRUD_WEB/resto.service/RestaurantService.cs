using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resto.Core.Data;
using Resto.Data;

namespace Resto.Service
{
    public class RestaurantService : IRestaurantService
    {
        private IRepository<Restaurant> restaurantRepository;
        public RestaurantService(IRepository<Restaurant> restaurant)
        {
           this.restaurantRepository = restaurant;
        }

        public IQueryable<Restaurant> GetItems()
        {
            return restaurantRepository.Table;
        }
    }
}
