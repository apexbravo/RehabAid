using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RehabAid.Data
{
    public partial class Attachment
    {
        public Attachment()
        {
            TreatmentFacility = new HashSet<TreatmentFacility>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? UniqueId { get; set; }
        public string Container { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public string NotesJson { get; set; }
        public string Extension { get; set; }

        public virtual User Creator { get; set; }
        public virtual ICollection<TreatmentFacility> TreatmentFacility { get; set; }
    }
}
