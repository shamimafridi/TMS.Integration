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
    
    public partial class vwTransDetailAll
    {
        public string TYPE { get; set; }
        public Nullable<int> IsLocalTrip { get; set; }
        public string InvoiceRefNo { get; set; }
        public string BranchCode { get; set; }
        public string Description { get; set; }
        public string TransactionNature { get; set; }
        public string TransactionNo { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string TransactionTypeCode { get; set; }
        public Nullable<decimal> AmountReceived { get; set; }
        public Nullable<decimal> AmountPaid { get; set; }
        public Nullable<long> RecordNo { get; set; }
        public string VehicleCode { get; set; }
    }
}
