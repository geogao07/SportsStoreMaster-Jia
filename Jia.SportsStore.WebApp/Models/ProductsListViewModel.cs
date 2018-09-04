using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jia.SportsStore.Domain.Entities;

namespace Jia.SportsStore.WebApp.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}