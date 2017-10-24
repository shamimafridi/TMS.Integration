using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TMS.Common.Enum;
using TMS.Common.ServicePattren;
using TMS.Integration.Services.CoaControlService.Dto;
using TMS.Integration.Storage;

namespace TMS.Integration.Services.CoaGeneralService
{
    public class CoaGeneralPostService : PostServiceHandler<PostResponse>
    {
        public CoaGeneralPostService()
        {

        }


        public override async Task<PostResponse> AsyncSetter(string token)
        {
            using (var context = new Storage.TMSEntities())
            {
                foreach (var coaLocal in GetCoaGeneral(context))
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

        private static List<LocalGeneral> GetCoaGeneral(TMSEntities context)
        {
            return (from control in context.COAControls
                    join coaGeneral in context.COAGenerals on control.ControlCode equals coaGeneral.ControlCode
                    select new LocalGeneral
                    {
                        GeneralCode = coaGeneral.GeneralCode,
                        RefNo = coaGeneral.RefNo,
                        Name = coaGeneral.GeneralDescription,
                        ControlRefNo = control.RefNo,
                        ControlCode = control.ControlCode
                    }
            ).ToList();
        }

        private class LocalGeneral
        {
            public string GeneralCode { get; set; }
            public string Name { get; set; }
            public string ControlCode { get; set; }
            public string ControlRefNo { get; set; }

            public string RefNo { get; set; }

        }


        private async Task Create(LocalGeneral coaLocal)
        {
            var response = _client.PostAsJsonAsync("api/coa",
                new CoaControlPostRequestBody
                {
                    desc = coaLocal.Name,
                    name = coaLocal.Name,
                    parent = coaLocal.ControlRefNo
                }).Result;
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsAsync<CoaControlPostResponse>();
            coaLocal.RefNo = contents._id;
            using (var context = new TMSEntities())
            {
                var general = context.COAGenerals.FirstOrDefault(w =>
                    w.ControlCode == coaLocal.ControlCode && w.GeneralCode == coaLocal.GeneralCode);
                if (general != null)
                {
                    general.RefNo = contents._id;
                    general.UpdatedOn = DateTime.Now;
                }
                context.SaveChanges();
            }

        }
        private async Task Update(string id, LocalGeneral coaLocal)
        {

            var response = _client.PutAsJsonAsync("api/coa/" + id,
                new CoaControlPostRequestBody
                {
                    desc = coaLocal.Name,
                    name = coaLocal.Name,
                    parent = coaLocal.ControlRefNo
                }).Result;
            response.EnsureSuccessStatusCode();
            var contentResult = await response.Content.ReadAsAsync<CoaControlPostResponse>();
            coaLocal.RefNo = contentResult._id;
            // coaLocal.UpdatedOn = DateTime.Now;
        }

    }
}
