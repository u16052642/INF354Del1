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
    
    public partial class CancerTypeTreatment
    {
        public int Cancer_Treat_ID { get; set; }
        public int Treat_Type_ID { get; set; }
        public int CancerType_ID { get; set; }
        public byte[] Cancer_Treat_Image { get; set; }
        public int Treat_ID { get; set; }
    
        public virtual CancerType CancerType { get; set; }
        public virtual Treatment Treatment { get; set; }
    }
}