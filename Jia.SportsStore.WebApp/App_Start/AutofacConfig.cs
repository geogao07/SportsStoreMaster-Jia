using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Moq;
using Jia.SportsStore.Domain.Abstract;
using Jia.SportsStore.Domain.Concrete;
using Jia.SportsStore.Domain.Entities;
using Jia.SportsStore.Domain.Mock;

namespace Jia.SportsStore.WebApp
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance<IProductsRepository>(new EFProductRepository());
            builder.RegisterInstance<IOrderProcessor>(new EmailOrderProcessor(new EmailSettings()));


            builder.RegisterControllers(AppDomain.CurrentDomain.GetAssemblies());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));//tell .net mvc to use which resolver
        }
    }
}