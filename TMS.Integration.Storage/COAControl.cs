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
    
    public partial class COAControl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COAControl()
        {
            this.COAGenerals = new HashSet<COAGeneral>();
        }
    
        public string ControlCode { get; set; }
        public string ControlDescription { get; set; }
        public System.DateTime DefinitionDate { get; set; }
        public long GUID { get; set; }
        public string FSFGLCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COAGeneral> COAGenerals { get; set; }
    }
}
