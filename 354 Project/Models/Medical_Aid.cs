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
    
    public partial class Medical_Aid
    {
        public int Med_Aid_ID { get; set; }
        public int User_IDs { get; set; }
        public int Med_Aid_Num { get; set; }
        public string Member_Name { get; set; }
        public int Member_IDNum { get; set; }
        public int MainMember_IDNum { get; set; }
    
        public virtual Userr Userr { get; set; }
    }
}
