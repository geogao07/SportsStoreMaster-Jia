using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jia.SportsStore.Domain.Concrete;
using Jia.SportsStore.Domain.Entities;

namespace Jia.SportsStore.DebugConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EFDbContext())
            {

                for (int i = 0; i < 20; i++)
                {
                    var product = new Product()
                    {
                        Name = "abc"+i.ToString(),
                        Description = "efg"+i.ToString(),
                        Category = "hij"+i.ToString(),
                        Price = 123,

                    };
                    ctx.Products.Add(product);

                }
                ctx.SaveChanges();
            }
        }
    }
}
