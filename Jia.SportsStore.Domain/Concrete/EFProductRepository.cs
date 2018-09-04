using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jia.SportsStore.Domain.Abstract;
using Jia.SportsStore.Domain.Entities;

namespace Jia.SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductsRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get {
                return context.Products;
            }
        }
    }
}
