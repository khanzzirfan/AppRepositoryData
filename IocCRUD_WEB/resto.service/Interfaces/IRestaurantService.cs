using Resto.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Service
{
    public interface IRestaurantService
    {
        IQueryable<Restaurant> GetItems();

    }
}
