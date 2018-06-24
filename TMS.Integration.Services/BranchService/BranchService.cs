using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TMS.Common.Enum;
using TMS.Common.ServicePattren;
using TMS.Integration.Services.BranchService.Dto;
using TMS.Integration.Storage;

namespace TMS.Integration.Services.BranchService
{
    public class BranchPostService : PostServiceHandler<PostResponse>
    {
        
        public override async Task<PostResponse> AsyncSetter(string token)
        {
            using (var context = new Storage.TMSEntities())
            {
                foreach (var local in context.Branches.ToList())
                {
                    await (string.IsNullOrEmpty(local.RefNo) ?
                        Create(local) :
                        Update(local.RefNo, local));

                    context.SaveChanges();
                }
                return new PostResponse
                {
                    NoOfRecordEffected = 10,
                    Status = ResponseStatus.Ok.ToString()
                };

            }
            //Storage.Branch
        }

        private async Task Create(Branch coaLocal)
        {
            var response = _client.PostAsJsonAsync("api/branch",
                new BranchPostRequestBody
                {
                    desc = coaLocal.BranchDescription,
                    name = coaLocal.BranchDescription,
                }).Result;
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsAsync<BranchPostResponse>();
            coaLocal.RefNo = contents._id;
            coaLocal.UpdatedOn = DateTime.Now;
        }
        private async Task Update(string id, Branch coaLocal)
        {
            var response =  _client.PutAsJsonAsync("api/branch/" + id,
                new BranchPostRequestBody
                {
                    desc = coaLocal.BranchDescription,
                    name = coaLocal.BranchDescription,
                }).Result;
            response.EnsureSuccessStatusCode();
            var contentResult = await response.Content.ReadAsAsync<BranchPostResponse>();
            coaLocal.RefNo = contentResult._id;
            coaLocal.UpdatedOn = DateTime.Now;
        }

    }
}
