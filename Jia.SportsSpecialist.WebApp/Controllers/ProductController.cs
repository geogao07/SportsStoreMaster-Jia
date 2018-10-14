using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jia.SportsSpecialist.Domain.Abstract;
using Jia.SportsSpecialist.Domain.Entities;
using Jia.SportsSpecialist.WebApp.Models;

namespace Jia.SportsSpecialist.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository repository;

        public int PageSize = 3;

        public ProductController(IProductsRepository productsRepository)
        {
            this.repository = productsRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository
                .Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository
                     .Products
                     .Where(p => category == null || p.Category == category)
                     .Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = repository
                .Products
                .FirstOrDefault(p => p.ProductId == productId);

            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

    }
}