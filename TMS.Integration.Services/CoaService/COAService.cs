using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TMS.Common.ServicePattren;
using TMS.Integration.Services.CoaService.Dto;

namespace TMS.Integration.Services.COAService
{
    public class CoaPostService : PostServiceHandler<CoaPostResponse>
    {
        public CoaPostService() 
        {
           
        }
       

        public override async Task<CoaPostResponse> AsyncSetter(string token)
        {
            using (var context = new Storage.TMSEntities())
            {
                foreach (var coaLocal in context.COAControls.ToList())
                {
                    var response = _client.PostAsJsonAsync("api/coa",
                        new CoaPostRequestBody
                        {
                            desc = coaLocal.ControlDescription,
                            name = coaLocal.ControlDescription,
                            parent = ""
                        }).Result;
                    response.EnsureSuccessStatusCode();
                    var contents = await response.Content.ReadAsAsync<CoaPostResponse>();
                    coaLocal.Ref_No = contents._id;
                    coaLocal.UpdatedOn = DateTime.Now;
                    context.SaveChanges();


                }
                return null;

            }
            //Storage.COAControl
        }
    }
}
