﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RehabAid.Data
{
    public partial class Guardians
    {
        public Guardians()
        {
            Reservation = new HashSet<Reservation>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? Relationship { get; set; }
        public Guid? FacilityId { get; set; }
        public Guid? PatientId { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }

        public virtual TreatmentFacility Facility { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
