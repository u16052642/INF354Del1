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
    
    public partial class User_Medication
    {
        public int User_Med_ID { get; set; }
        public string User_Med_Name { get; set; }
        public string User_Med_Description { get; set; }
        public int User_IDs { get; set; }
    
        public virtual Userr Userr { get; set; }
    }
}