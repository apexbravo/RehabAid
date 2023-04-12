using RehabAid.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace RehabAid.Data
{
   partial class Patient
    {
        [NotMapped]
        public Gender Gender
        {
            get => (Gender)GenderId;
            set => GenderId = (int)value;
        }

        [NotMapped]
        public string Fullname => string.Join(" ", new string[] { FirstName, Surname }.Where(c => !string.IsNullOrWhiteSpace(c)));

    }
}
