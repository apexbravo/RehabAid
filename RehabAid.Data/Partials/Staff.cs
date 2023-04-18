using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace RehabAid.Data
{
    partial class Staff
    {

        [NotMapped]
        public string Fullname => string.Join(" ", new string[] { FirstName, Surname }.Where(c => !string.IsNullOrWhiteSpace(c)));
    }
}
