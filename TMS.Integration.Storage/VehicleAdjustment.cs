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
    
    public partial class VehicleAdjustment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleAdjustment()
        {
            this.VehicleAdjustmentDetails = new HashSet<VehicleAdjustmentDetail>();
        }
    
        public string BranchCode { get; set; }
        public string VehicleAdjustmentNature { get; set; }
        public string VehicleAdjustmentNo { get; set; }
        public System.DateTime VehicleAdjustmentDate { get; set; }
        public string VehicleCode { get; set; }
        public string Description { get; set; }
        public string Mode { get; set; }
        public string ChequeNo { get; set; }
        public Nullable<bool> Locked { get; set; }
        public Nullable<bool> Posted { get; set; }
        public long RecordNo { get; set; }
        public Nullable<long> CreditDays { get; set; }
        public string OldRef { get; set; }
        public string UrduTitle { get; set; }
        public int GUID { get; set; }
        public string InvoiceRefNo { get; set; }
        public string RefNo { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        public virtual Branch Branch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleAdjustmentDetail> VehicleAdjustmentDetails { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
