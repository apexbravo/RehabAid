using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RehabAid.Data
{
    public partial class User
    {
        public User()
        {
            Attachment = new HashSet<Attachment>();
            PatientAttentance = new HashSet<PatientAttentance>();
            ProgressReport = new HashSet<ProgressReport>();
            ProgressReports = new HashSet<ProgressReports>();
            Reservation = new HashSet<Reservation>();
            Specialist = new HashSet<Specialist>();
            SpecialistAppointment = new HashSet<SpecialistAppointment>();
            SpecialistReview = new HashSet<SpecialistReview>();
            Staff = new HashSet<Staff>();
            TreatmentFacility = new HashSet<TreatmentFacility>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LoginId { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool IsActive { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string AuthenticatorKey { get; set; }
        public string AuthRecoveryCodes { get; set; }
        public bool TwoFactorAuthEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTime? LockoutExpiryDate { get; set; }
        public DateTime? ActivationDate { get; set; }
        public bool IsMobileConfirmed { get; set; }
        public Guid? CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid? StaffId { get; set; }
        public Guid? SpecialistId { get; set; }
        public Guid? GuardianId { get; set; }

        public virtual Guardians Guardian { get; set; }
        public virtual Specialist SpecialistNavigation { get; set; }
        public virtual Staff StaffNavigation { get; set; }
        public virtual ICollection<Attachment> Attachment { get; set; }
        public virtual ICollection<PatientAttentance> PatientAttentance { get; set; }
        public virtual ICollection<ProgressReport> ProgressReport { get; set; }
        public virtual ICollection<ProgressReports> ProgressReports { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
        public virtual ICollection<Specialist> Specialist { get; set; }
        public virtual ICollection<SpecialistAppointment> SpecialistAppointment { get; set; }
        public virtual ICollection<SpecialistReview> SpecialistReview { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
        public virtual ICollection<TreatmentFacility> TreatmentFacility { get; set; }
    }
}
