using RehabAid.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace RehabAid.Data
{
   partial class Specialist
    {
        [NotMapped]
        public string Fullname => string.Join(" ", new string[] { FirstName, Surname }.Where(c => !string.IsNullOrWhiteSpace(c)));

        [NotMapped]
        public SpecialtyType Specialty
        {
           get => (SpecialtyType)SpecialtyId;
           set => SpecialtyId = (int)value;
        }

       
    }
}

    

