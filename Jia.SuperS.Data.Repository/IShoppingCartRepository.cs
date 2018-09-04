using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jia.SuperS.Data.Model;

namespace Jia.SuperS.Data.Repository
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetById(int id);
        ShoppingCart Create();
        ShoppingCart Update(int id, ShoppingCart newValue);
    }
}
