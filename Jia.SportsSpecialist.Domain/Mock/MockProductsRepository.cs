using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jia.SportsSpecialist.Domain.Abstract;
using Jia.SportsSpecialist.Domain.Entities;

namespace Jia.SportsSpecialist.Domain.Mock
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

        public Product DeleteProduct(int productId)
        {
            return new Product();
        }

        public void SaveProduct(Product product)
        {
        }
    }
}
