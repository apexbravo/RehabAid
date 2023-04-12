using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RehabAid.Data
{
    public partial class Reservation
    {
        public Guid Id { get; set; }
        public Guid? GuardianId { get; set; }
        public Guid? FacilityId { get; set; }
        public Guid? CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual User Creator { get; set; }
        public virtual Guardians Guardian { get; set; }
    }
}
