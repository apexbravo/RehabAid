using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RehabAid.Data
{
    public partial class Specialist
    {
        public Specialist()
        {
            PatientAttentance = new HashSet<PatientAttentance>();
            SpecialistReview = new HashSet<SpecialistReview>();
            User = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? Dob { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Email { get; set; }
        public int? SpecialtyId { get; set; }

        public virtual User Creator { get; set; }
        public virtual ICollection<PatientAttentance> PatientAttentance { get; set; }
        public virtual ICollection<SpecialistReview> SpecialistReview { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
