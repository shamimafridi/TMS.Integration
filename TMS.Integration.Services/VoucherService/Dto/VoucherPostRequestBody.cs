using System;
using System.Collections.Generic;
using TMS.Integration.Services.Common.Dto;

namespace TMS.Integration.Services.VoucherService.Dto
{
    class VoucherPostRequestBody
    {
        public GeneralDto branch { set; get; }
        public DateTime date { get; set; }
        public string desc { get; set; }
        public List<VoucherDetailBodyRequest> voucher_detail { get; set; }

    }
    class VoucherDetailBodyRequest
    {
        public string narration { get; set; }
        public string reference { get; set; }
        public decimal? debit { get; set; }
        public decimal? credit { get; set; }
        public GeneralDto coa { get; set; }

    }

}
