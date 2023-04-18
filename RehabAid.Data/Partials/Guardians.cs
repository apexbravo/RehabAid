using System;
using RehabAid.Lib;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;


namespace RehabAid.Data
{
    partial class Guardians
    {
        [NotMapped]
        public string Fullname => string.Join(" ", new string[] { FirstName, Surname }.Where(c => !string.IsNullOrWhiteSpace(c)));

    }
}
