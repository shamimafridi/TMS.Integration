﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

using System.Web.Http;
using TMS.Integration.Api.Helper;
using TMS.Integration.Services.COAService;
using TMS.Integration.Services.CustomerService;
using TMS.Common.ServicePattren;

namespace TMS.Integration.Api.Configs
{
    public static class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            //container.RegisterType<ICustomerService, CustomerService>(new HierarchicalLifetimeManager());
            container.RegisterType(typeof(IPostServiceHandler<>),typeof( PostServiceHandler<>),new HierarchicalLifetimeManager());

            container.RegisterType(typeof(CoaPostService));
            container.RegisterType<ICustomerService, CustomerService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

        }
    }
}