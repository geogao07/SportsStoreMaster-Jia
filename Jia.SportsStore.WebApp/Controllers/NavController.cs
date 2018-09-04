﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jia.SportsStore.Domain.Abstract;

namespace Jia.SportsStore.WebApp.Controllers
{
    public class NavController : Controller
    {
        private IProductsRepository repository;
        public NavController(IProductsRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository
            .Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x)
            .ToArray()
            .Where(x => !string.IsNullOrWhiteSpace(x));


            return PartialView(categories);
        }
    }
}