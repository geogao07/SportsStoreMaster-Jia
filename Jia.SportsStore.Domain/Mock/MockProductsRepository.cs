using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jia.SportsStore.Domain.Abstract;
using Jia.SportsStore.Domain.Entities;

namespace Jia.SportsStore.Domain.Mock
{
    public class MockProductsRepository : IProductsRepository
    {
        public IEnumerable<Product> Products
        {
            get
            {
                return new List<Product>
                {
                    new Product { Name = "Football", Price = 25 },
                    new Product { Name = "Surf board", Price = 179 },
                    new Product { Name = "Running shoes", Price = 95 }
                };
            }
        }
    }
}
