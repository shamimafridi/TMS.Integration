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
    
    public partial class Voucher
    {
        public string BranchCode { get; set; }
        public string VoucherNature { get; set; }
        public string VoucherNo { get; set; }
        public System.DateTime VoucherDate { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Locked { get; set; }
        public Nullable<bool> Posted { get; set; }
        public Nullable<bool> IsAutoGenerated { get; set; }
        public long RecordNo { get; set; }
        public Nullable<long> CreditDays { get; set; }
        public string OldRef { get; set; }
        public string UrduTitle { get; set; }
        public int GUID { get; set; }
    
        public virtual Branch Branch { get; set; }
    }
}