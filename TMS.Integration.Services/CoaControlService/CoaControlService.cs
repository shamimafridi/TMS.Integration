using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TMS.Common.Enum;
using TMS.Common.ServicePattren;
using TMS.Integration.Services.CoaControlService.Dto;
using TMS.Integration.Storage;

namespace TMS.Integration.Services.CoaControlService
{
    public class CoaControlPostService : PostServiceHandler<PostResponse>
    {
        public CoaControlPostService()
        {

        }
        public override async Task<PostResponse> AsyncSetter(string token)
        {
            using (var context = new Storage.TMSEntities())
            {
                var coaControls = context.COAControls.ToList();
                foreach (var coaLocal in coaControls)
                {
                    await (string.IsNullOrEmpty(coaLocal.RefNo) ?
                        Create(coaLocal) :
                        Update(coaLocal.RefNo, coaLocal));

                    context.SaveChanges();
                }
                return new PostResponse
                {
                    NoOfRecordEffected = 10,
                    Status = ResponseStatus.Ok.ToString()
                };

            }
            //Storage.COAControl
        }

        private async Task Create(COAControl coaLocal)
        {
            var response = _client.PostAsJsonAsync("api/coa",
                new CoaControlPostRequestBody
                {
                    desc = coaLocal.ControlDescription,
                    name = coaLocal.ControlDescription,
                    parent = ""
                }).Result;
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsAsync<CoaControlPostResponse>();
            coaLocal.RefNo = contents._id;
            coaLocal.UpdatedOn = DateTime.Now;
        }
        private async Task Update(string id, COAControl coaLocal)
        {

            var response = _client.PutAsJsonAsync("api/coa/" + id,
                new CoaControlPostRequestBody
                {
                    desc = coaLocal.ControlDescription,
                    name = coaLocal.ControlDescription,
                    parent = ""
                }).Result;
            response.EnsureSuccessStatusCode();
            var contentResult = await response.Content.ReadAsAsync<CoaControlPostResponse>();
            coaLocal.RefNo = contentResult._id;
            coaLocal.UpdatedOn = DateTime.Now;
        }

    }
}
