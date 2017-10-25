using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TMS.Common.Enum;
using TMS.Common.ServicePattren;
using TMS.Integration.Services.CoaControlService.Dto;
using TMS.Integration.Storage;

namespace TMS.Integration.Services.CoaSubsidiaryService
{
    public class CoaSubsidiaryPostService : PostServiceHandler<PostResponse>
    {
        public override async Task<PostResponse> AsyncSetter(string token)
        {
            using (var context = new Storage.TMSEntities())
            {
                foreach (var coaLocal in GetCoaSubsidiaries(context))
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

        private static List<LocalSubsidiaries> GetCoaSubsidiaries(TMSEntities context)
        {
            return (from coaGeneral in context.COAGenerals
                    join coaSubsidiaries in context.COASubsidiaries on
                    new { coaGeneral.ControlCode, coaGeneral.GeneralCode }
                    equals new
                    {
                        coaSubsidiaries.ControlCode,
                        coaSubsidiaries.GeneralCode
                    }
                    select new LocalSubsidiaries
                    {
                        SubsidiaryCode = coaSubsidiaries.SubsidiaryCode,
                        RefNo = coaSubsidiaries.RefNo,
                        GeneralCode = coaSubsidiaries.GeneralCode,
                        Name = coaSubsidiaries.SubsidiaryDescription,
                        GeneralRefNo = coaGeneral.RefNo,
                        ControlCode = coaGeneral.ControlCode
                    }
            ).ToList();
        }

        private class LocalSubsidiaries
        {
            public string SubsidiaryCode { get; set; }
            public string Name { get; set; }
            public string GeneralCode { get; set; }
            public string ControlCode { get; set; }
            public string GeneralRefNo { get; set; }
            public string RefNo { get; set; }

        }


        private async Task Create(LocalSubsidiaries coaLocal)
        {
            var response = _client.PostAsJsonAsync("api/coa",
                new CoaControlPostRequestBody
                {
                    desc = coaLocal.Name,
                    name = coaLocal.Name,
                    parent = coaLocal.GeneralRefNo
                }).Result;
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsAsync<CoaControlPostResponse>();
            coaLocal.RefNo = contents._id;
            using (var context = new TMSEntities())
            {
                var Subsidiaries = context.COASubsidiaries.FirstOrDefault(w =>
                    w.ControlCode == coaLocal.ControlCode && w.SubsidiaryCode == coaLocal.SubsidiaryCode && w.GeneralCode==coaLocal.GeneralCode);
                if (Subsidiaries != null)
                {
                    Subsidiaries.RefNo = contents._id;
                    Subsidiaries.UpdatedOn = DateTime.Now;
                }
                context.SaveChanges();
            }

        }
        private async Task Update(string id, LocalSubsidiaries coaLocal)
        {

            var response = _client.PutAsJsonAsync("api/coa/" + id,
                new CoaControlPostRequestBody
                {
                    desc = coaLocal.Name,
                    name = coaLocal.Name,
                    parent = coaLocal.GeneralRefNo
                }).Result;
            response.EnsureSuccessStatusCode();
            var contentResult = await response.Content.ReadAsAsync<CoaControlPostResponse>();
            coaLocal.RefNo = contentResult._id;
            // coaLocal.UpdatedOn = DateTime.Now;
        }

    }
}
