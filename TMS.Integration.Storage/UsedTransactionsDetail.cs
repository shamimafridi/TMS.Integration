//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TMS.Integration.Storage
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsedTransactionsDetail
    {
        public long RecordNo { get; set; }
        public string BranchCode { get; set; }
        public string VoucherNature { get; set; }
        public string VoucherNo { get; set; }
        public System.DateTime VoucherDate { get; set; }
        public string GLCode { get; set; }
        public string BillNo { get; set; }
        public string RefVoucherNature { get; set; }
        public string RefVoucherNo { get; set; }
        public System.DateTime RefVoucherDate { get; set; }
        public string RefBillNo { get; set; }
        public decimal AmountUsed { get; set; }
        public string RefNo { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}
