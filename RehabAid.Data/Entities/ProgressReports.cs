using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RehabAid.Data
{
    public partial class ProgressReports
    {
        public Guid Id { get; set; }
        public Guid GuardianId { get; set; }
        public Guid PatientId { get; set; }
        public string TherapyReview { get; set; }
        public Guid? CreatorId { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual User Creator { get; set; }
        public virtual Guardians Guardian { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
