using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RehabAid.Data
{
    public partial class Patient
    {
        public Patient()
        {
            Guardians = new HashSet<Guardians>();
            MedicineLog = new HashSet<MedicineLog>();
            PatientAttentance = new HashSet<PatientAttentance>();
            SpecialistReview = new HashSet<SpecialistReview>();
            User = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public Guid? FacilityId { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string EmergencyContact { get; set; }
        public int GenderId { get; set; }
        public Guid CreatorId { get; set; }
        public string FirstName { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual TreatmentFacility Facility { get; set; }
        public virtual ICollection<Guardians> Guardians { get; set; }
        public virtual ICollection<MedicineLog> MedicineLog { get; set; }
        public virtual ICollection<PatientAttentance> PatientAttentance { get; set; }
        public virtual ICollection<SpecialistReview> SpecialistReview { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
