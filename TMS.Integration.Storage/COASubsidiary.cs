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
    
    public partial class COASubsidiary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COASubsidiary()
        {
            this.COASubSubsidiaries = new HashSet<COASubSubsidiary>();
        }
    
        public string ControlCode { get; set; }
        public string GeneralCode { get; set; }
        public string SubsidiaryCode { get; set; }
        public string SubsidiaryDescription { get; set; }
        public System.DateTime DefinitionDate { get; set; }
        public long GUID { get; set; }
        public string FSFGLCode { get; set; }
    
        public virtual COAGeneral COAGeneral { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COASubSubsidiary> COASubSubsidiaries { get; set; }
    }
}
