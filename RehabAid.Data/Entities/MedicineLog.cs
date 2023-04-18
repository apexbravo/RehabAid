using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RehabAid.Data
{
    public partial class MedicineLog
    {
        public MedicineLog()
        {
            ProgressReport = new HashSet<ProgressReport>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? PatientId { get; set; }
        public Guid DateIssued { get; set; }
        public Guid? CreatorId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string PrescriptionLabel { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual ICollection<ProgressReport> ProgressReport { get; set; }
    }
}
