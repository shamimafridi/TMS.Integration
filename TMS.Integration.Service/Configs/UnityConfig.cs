using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

using System.Web.Http;
using TMS.Integration.Api.Helper;
using TMS.Common.ServicePattren;
using TMS.Integration.Services.BranchService;
using TMS.Integration.Services.CoaControlService;
using TMS.Integration.Services.CoaGeneralService;
using TMS.Integration.Services.CoaSubsidiaryService;
using TMS.Integration.Services.CoaSubSubsidiaryService;
using TMS.Integration.Services.VoucherService;

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
            container.RegisterType(typeof(BranchPostService));

            container.RegisterType(typeof(CoaSubsidiaryPostService));
            container.RegisterType(typeof(CoaSubSubsidiaryPostService));
            container.RegisterType(typeof(VoucherPostService));


            config.DependencyResolver = new UnityResolver(container);

        }
    }
}