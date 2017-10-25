using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

using System.Web.Http;
using TMS.Integration.Api.Helper;
using TMS.Common.ServicePattren;
using TMS.Integration.Services.CoaControlService;
using TMS.Integration.Services.CoaGeneralService;
using TMS.Integration.Services.CoaSubsidiaryService;

namespace TMS.Integration.Api.Configs
{
    public static class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType(typeof(IPostServiceHandler<>),typeof( PostServiceHandler<>),new HierarchicalLifetimeManager());

            container.RegisterType(typeof(CoaControlPostService));
            container.RegisterType(typeof(CoaGeneralPostService));

            container.RegisterType(typeof(CoaSubsidiaryPostService));
            config.DependencyResolver = new UnityResolver(container);

        }
    }
}