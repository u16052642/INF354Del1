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
    
    public partial class Journal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Journal()
        {
            this.Userrs = new HashSet<Userr>();
        }
    
        public int Journal_ID { get; set; }
        public string Journal_Name { get; set; }
        public System.DateTime Journal_Date { get; set; }
        public string Journal_Entry { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Userr> Userrs { get; set; }
    }
}
