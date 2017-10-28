using TMS.Common.ServicePattren;

namespace TMS.Integration.Services.BranchService.Dto
{
    public class BranchPostResponse:PostResponse
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string parent { get; set; }

    }

    
}