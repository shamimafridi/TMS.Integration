using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TMS.Integration.Services.CoaService.Dto;
using TMS.Integration.Services.CustomerService;

namespace TMS.Integration.Services.COAService
{
    public class CoaService : ICoaService
    {
        private readonly HttpClient _client;
        public CoaService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["CloudApiBaseUrl"]);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6InNoYW1pbSIsImlhdCI6MTUwODY3MTA3Nn0.dFJhbvg7HjJWcDDxejU038js5sF_qFClG5iu0c73FHQ");
            _client.DefaultRequestHeaders.Add("subdomain", "azam");

        }
        public async Task<CoaPostResponse> AsyncSetter()
        {
            try
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
                        coaLocal.UpdatedOn=DateTime.Now;
                        context.SaveChanges();


                    }
                    return null;

                }
                //Storage.COAControl

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       
       
    }
}
