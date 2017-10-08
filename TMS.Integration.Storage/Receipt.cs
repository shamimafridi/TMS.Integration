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
    
    public partial class Receipt
    {
        public string BranchCode { get; set; }
        public string ReceiptNo { get; set; }
        public string BillNo { get; set; }
        public string CustomerCode { get; set; }
        public Nullable<System.DateTime> ReceiptDate { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Shortage { get; set; }
        public Nullable<decimal> TaxRate { get; set; }
        public Nullable<decimal> SaleTaxValue { get; set; }
        public Nullable<decimal> AmountIncSaleTax { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<byte> Locked { get; set; }
        public Nullable<byte> Posted { get; set; }
        public long RecordNo { get; set; }
    
        public virtual Branch Branch { get; set; }
        public virtual CustomerBill CustomerBill { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
