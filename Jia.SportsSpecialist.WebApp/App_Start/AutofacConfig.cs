using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Moq;
using Jia.SportsSpecialist.Domain.Abstract;
using Jia.SportsSpecialist.Domain.Concrete;
using Jia.SportsSpecialist.Domain.Entities;
using Jia.SportsSpecialist.Domain.Mock;
using Jia.SportsSpecialist.WebApp.Infrastructure.Abstract;
using Jia.SportsSpecialist.WebApp.Infrastructure.Concrete;
using System.Globalization;

namespace Jia.SportsSpecialist.WebApp
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(AppDomain.CurrentDomain.GetAssemblies());

            builder.RegisterInstance<IProductsRepository>(new EFProductRepository())
                .PropertiesAutowired();

            builder.RegisterInstance<IOrderProcessor>(new EmailOrderProcessor(new EmailSettings()));

            builder
                .RegisterInstance<IAuthProvider>(new FormsAuthProvider())
                .PropertiesAutowired();

            builder.RegisterType<EFDbContext>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

           
        }
    }
}