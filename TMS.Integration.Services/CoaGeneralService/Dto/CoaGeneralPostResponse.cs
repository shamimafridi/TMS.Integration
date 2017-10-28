using System;
using System.Collections.Generic;
using TMS.Common.ServicePattren;
using TMS.Integration.Storage;

namespace TMS.Integration.Services.CoaGeneralService.Dto
{
    public class CoaGeneralPostResponse:PostResponse
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string parent { get; set; }

    }

}