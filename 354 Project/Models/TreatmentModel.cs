using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _354_Project.Models
{
    public class TreatmentModel
    {
        public int Treat_ID { get; set; }

        public int Treat_Type_ID { get; set; }
        public string Treat_Name { get; set; }
        public string Treat_Description { get; set; }
        public byte[] Treat_Image { get; set; }
    }
}