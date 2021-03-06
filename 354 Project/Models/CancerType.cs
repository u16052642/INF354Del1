//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _354_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CancerType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CancerType()
        {
            this.CancerTypeTreatments = new HashSet<CancerTypeTreatment>();
            this.CancerType_Symptom = new HashSet<CancerType_Symptom>();
            this.Preventions = new HashSet<Prevention>();
            this.Resources = new HashSet<Resource>();
        }
    
        public int CancerType_ID { get; set; }
        public string CancerType_Name { get; set; }
        public string CancerType_Description { get; set; }
        public string CancerType_Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CancerTypeTreatment> CancerTypeTreatments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CancerType_Symptom> CancerType_Symptom { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prevention> Preventions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
