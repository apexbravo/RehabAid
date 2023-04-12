using RehabAid.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RehabAid.Data
{
    partial class Reservation
    {
        [NotMapped]
        public Status StatusType
        {
            get => (Status)Status;
            set => Status = (int)value;
        }
    }
}
