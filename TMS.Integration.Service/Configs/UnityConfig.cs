using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

using System.Web.Http;
using TMS.Integration.Api.Helper;
using TMS.Integration.Services.CustomerService;
namespace TMS.Integration.Api.Configs
{
    public static class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<ICustomerService, CustomerService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

        }
    }
}