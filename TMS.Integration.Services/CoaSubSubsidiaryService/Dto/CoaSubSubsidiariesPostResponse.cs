using TMS.Common.ServicePattren;

namespace TMS.Integration.Services.CoaSubSubsidiaryService.Dto
{
    public class CoaSubSubsidiaryPostResponse:PostResponse
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string parent { get; set; }

    }

    
}