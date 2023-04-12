using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RehabAid.Data
{
    public partial class PatientAttentance
    {
        public Guid Id { get; set; }
        public Guid? PatientId { get; set; }
        public Guid? SpecialistId { get; set; }
        public DateTime? Date { get; set; }
        public string Notes { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid CreatorId { get; set; }

        public virtual User Creator { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Specialist Specialist { get; set; }
    }
}
