using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Integration.Services.CoaService.Dto
{
    class CoaPostRequestBody
    {
        public string name { get; set; }
        public string desc { get; set; }
        public string parent { get; set; }

    }
}
