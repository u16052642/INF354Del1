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
    
    public partial class Resource
    {
        public int Res_ID { get; set; }
        public int CancerType_ID { get; set; }
        public string Res_Name { get; set; }
        public string Res_Description { get; set; }
        public string Res_Link { get; set; }
        public string Res_Image { get; set; }
    
        public virtual CancerType CancerType { get; set; }
    }
}
