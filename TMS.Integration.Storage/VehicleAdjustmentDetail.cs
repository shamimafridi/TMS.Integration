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
    
    public partial class VehicleAdjustmentDetail
    {
        public string BranchCode { get; set; }
        public string VehicleAdjustmentNature { get; set; }
        public string VehicleAdjustmentNo { get; set; }
        public string TransactionTypeCode { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string UrduDescription { get; set; }
        public string GLCode { get; set; }
        public string DivisionCode { get; set; }
        public string InvoiceRefNo { get; set; }
        public long RecordNo { get; set; }
    
        public virtual TransactionType TransactionType { get; set; }
        public virtual TransactionType TransactionType1 { get; set; }
        public virtual VehicleAdjustment VehicleAdjustment { get; set; }
    }
}
