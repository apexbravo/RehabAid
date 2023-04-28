using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RehabAid.Data
{
    public partial class TreatmentFacility
    {
        public TreatmentFacility()
        {
            Guardians = new HashSet<Guardians>();
            Patient = new HashSet<Patient>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? TypeId { get; set; }
        public string Address { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid? LogoId { get; set; }
        public string AttachmentJson { get; set; }
        public int? ProgramId { get; set; }
        public int? ServiceId { get; set; }
        public int? MaxLimit { get; set; }

        public virtual User Creator { get; set; }
        public virtual Attachment Logo { get; set; }
        public virtual ICollection<Guardians> Guardians { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
    }
}
