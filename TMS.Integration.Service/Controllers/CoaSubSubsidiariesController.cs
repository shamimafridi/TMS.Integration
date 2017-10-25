using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Routing;
using TMS.Common.ServicePattren;
using TMS.Integration.Api.Helper;
using TMS.Integration.Services.CoaGeneralService;
using TMS.Integration.Services.CoaSubSubsidiaryService;

namespace TMS.Integration.Api.Controllers
{
    public class CoaSubSubsidiariesController : ApiController
    {
        // GET: api/COAs
        private readonly CoaSubSubsidiaryPostService _service;
        public CoaSubSubsidiariesController(CoaSubSubsidiaryPostService service)
        {
            _service = service;
        }

        // GET: api/COAs/5
        [BasicAuthenticator("token")]
        public IHttpActionResult Get()
        {
            var response = _service.AsyncSetter(User.Identity.AuthenticationType);
            return Ok(response.Result);
        }

        // POST: api/COAs
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/COAs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/COAs/5
        public void Delete(int id)
        {
        }
    }
}
