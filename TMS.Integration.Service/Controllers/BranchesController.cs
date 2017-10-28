using System.Web.Http;
using TMS.Integration.Api.Helper;
using TMS.Integration.Services;
using TMS.Integration.Services.BranchService;

namespace TMS.Integration.Api.Controllers
{
    public class BranchesController : ApiController
    {
        // GET: api/COAs
        private readonly BranchPostService _service;
        public BranchesController(BranchPostService service)
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
