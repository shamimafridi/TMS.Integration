using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TMS.Common.Enum;
using TMS.Common.ServicePattren;
using TMS.Integration.Services.CoaControlService.Dto;
using TMS.Integration.Storage;

namespace TMS.Integration.Services.CoaSubSubsidiaryService
{
    public class CoaSubSubsidiaryPostService : PostServiceHandler<PostResponse>
    {
        public override async Task<PostResponse> AsyncSetter(string token)
        {
            using (var context = new Storage.TMSEntities())
            {
                foreach (var coaLocal in GetCoaSubSubsidiaries(context))
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

        private static List<LocalSubSubsidiaries> GetCoaSubSubsidiaries(TMSEntities context)
        {
            return (from coaSubsidiary in context.COASubsidiaries
                    join coaSubSubsidiaries in context.COASubSubsidiaries on
                    new { coaSubsidiary.ControlCode, coaSubsidiary.GeneralCode,coaSubsidiary.SubsidiaryCode }
                    equals new
                    {
                        coaSubSubsidiaries.ControlCode,
                        coaSubSubsidiaries.GeneralCode,
                        coaSubSubsidiaries.SubsidiaryCode
                    }
                    select new LocalSubSubsidiaries
                    {
                        SubSubsidiaryCode = coaSubSubsidiaries.SubSubsidiaryCode,
                        SubsidiaryCode = coaSubSubsidiaries.SubsidiaryCode,
                        RefNo = coaSubSubsidiaries.RefNo,
                        GeneralCode = coaSubSubsidiaries.GeneralCode,
                        Name = coaSubSubsidiaries.SubSubsidiaryDescription,
                        SubsidiaryRefNo = coaSubsidiary.RefNo,
                        ControlCode = coaSubsidiary.ControlCode
                    }
            ).ToList();
        }

        private class LocalSubSubsidiaries
        {
            public string SubSubsidiaryCode { get; set; }
            public string SubsidiaryCode { get; set; }

            public string Name { get; set; }
            public string GeneralCode { get; set; }
            public string ControlCode { get; set; }
            public string SubsidiaryRefNo { get; set; }
            public string RefNo { get; set; }

        }


        private async Task Create(LocalSubSubsidiaries coaLocal)
        {
            var response = _client.PostAsJsonAsync("api/coa",
                new CoaControlPostRequestBody
                {
                    desc = coaLocal.Name,
                    name = coaLocal.Name,
                    parent = coaLocal.SubsidiaryRefNo
                }).Result;
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsAsync<CoaControlPostResponse>();
            coaLocal.RefNo = contents._id;
            using (var context = new TMSEntities())
            {
                var SubSubsidiaries = context.COASubSubsidiaries.FirstOrDefault(w =>
                    w.ControlCode == coaLocal.ControlCode && w.SubSubsidiaryCode == coaLocal.SubSubsidiaryCode 
                    && w.GeneralCode==coaLocal.GeneralCode
                    && w.SubsidiaryCode == coaLocal.SubsidiaryCode);
                if (SubSubsidiaries != null)
                {
                    SubSubsidiaries.RefNo = contents._id;
                    SubSubsidiaries.UpdatedOn = DateTime.Now;
                }
                context.SaveChanges();
            }

        }
        private async Task Update(string id, LocalSubSubsidiaries coaLocal)
        {

            var response = _client.PutAsJsonAsync("api/coa/" + id,
                new CoaControlPostRequestBody
                {
                    desc = coaLocal.Name,
                    name = coaLocal.Name,
                    parent = coaLocal.SubsidiaryRefNo
                }).Result;
            response.EnsureSuccessStatusCode();
            var contentResult = await response.Content.ReadAsAsync<CoaControlPostResponse>();
            coaLocal.RefNo = contentResult._id;
            // coaLocal.UpdatedOn = DateTime.Now;
        }

    }
}
