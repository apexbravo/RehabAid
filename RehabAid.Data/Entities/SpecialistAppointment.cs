using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RehabAid.Data
{
    public partial class SpecialistAppointment
    {
        public Guid Id { get; set; }
        public Guid? SpecialistId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User Creator { get; set; }
    }
}
