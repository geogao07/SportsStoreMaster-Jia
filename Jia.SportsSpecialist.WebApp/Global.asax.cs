using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Jia.SportsSpecialist.Domain.Entities;
using Jia.SportsSpecialist.WebApp.Infrastructure.Binders;

namespace Jia.SportsSpecialist.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutofacConfig.Register();

            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            
        }
    }
}
