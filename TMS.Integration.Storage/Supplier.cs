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
    
    public partial class Supplier
    {
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string UrduTitle { get; set; }
        public string Address { get; set; }
        public string CityCode { get; set; }
        public string PostalCode { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string eMail { get; set; }
        public string SalesTaxNumber { get; set; }
        public string NationalTaxNumber { get; set; }
        public string TaxCircle { get; set; }
        public string TaxZone { get; set; }
        public Nullable<System.DateTime> DefinitionDate { get; set; }
        public long GUID { get; set; }
    
        public virtual City City { get; set; }
    }
}
