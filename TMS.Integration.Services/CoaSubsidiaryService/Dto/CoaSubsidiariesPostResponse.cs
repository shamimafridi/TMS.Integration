﻿using TMS.Common.ServicePattren;

namespace TMS.Integration.Services.CoaSubsidiaryService.Dto
{
    public class CoaSubsidiaryPostResponse:PostResponse
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string parent { get; set; }

    }

    
}