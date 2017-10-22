using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Permissions;
using System.Security.Principal;
using System.Web.Http;
using TMS.Integration.Api.Helper;
using TMS.Integration.Api.Models;
using TMS.Integration.Services.CustomerService;

namespace TMS.Integration.Api.Controllers
{
    public class CustomersController : ApiController
    {
        private ICustomerService _service;
        public CustomersController(ICustomerService service)
        {
            _service = service;
        }
        //public CustomersController() : base()
        //{
        //}
        [BasicAuthenticator("bb")]
        public IHttpActionResult Get()
        {
            
            
            var response = _service.AsyncSetter();
            return Ok(response.Result);
        }
    }
}
