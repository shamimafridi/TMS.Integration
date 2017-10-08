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
    
    public partial class ProductRate
    {
        public string ProductCode { get; set; }
        public System.DateTime EffectiveDate { get; set; }
        public string StationPointCode { get; set; }
        public string DestinationPointCode { get; set; }
        public Nullable<decimal> TripAdvanceAmount { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<long> GUID { get; set; }
    
        public virtual DestinationPoint DestinationPoint { get; set; }
        public virtual Product Product { get; set; }
        public virtual StationPoint StationPoint { get; set; }
    }
}