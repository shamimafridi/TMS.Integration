using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using TMS.Integration.Services.COAService;

namespace TMS.Integration.Api.Controllers
{
    public class CoaController : ApiController
    {
        // GET: api/COAs
        private ICoaService _service;
        public CoaController(ICoaService service)
        {
            _service = service;
        }

        // GET: api/COAs/5
        public IHttpActionResult Get()
        {
            var response = _service.AsyncSetter();
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
