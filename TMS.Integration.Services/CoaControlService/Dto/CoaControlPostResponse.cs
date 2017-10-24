using TMS.Common.ServicePattren;

namespace TMS.Integration.Services.CoaControlService.Dto
{
    public class CoaControlPostResponse:PostResponse
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string parent { get; set; }

    }

    
}