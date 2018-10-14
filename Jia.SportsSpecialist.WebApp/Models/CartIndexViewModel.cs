using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jia.SportsSpecialist.Domain.Entities;

namespace Jia.SportsSpecialist.WebApp.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}