using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jia.SportsStore.Domain.Entities;

namespace Jia.SportsStore.Domain.Abstract
{
    public interface IProductsRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
