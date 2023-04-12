using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RehabAid.Data
{
    public partial class RehabAidContext : DbContext
    {
        public RehabAidContext()
        {
        }

        public RehabAidContext(DbContextOptions<RehabAidContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<Guardians> Guardians { get; set; }
        public virtual DbSet<MedicineLog> MedicineLog { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientAttentance> PatientAttentance { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Specialist> Specialist { get; set; }
        public virtual DbSet<SpecialistAppointment> SpecialistAppointment { get; set; }
        public virtual DbSet<SpecialistReview> SpecialistReview { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<TreatmentFacility> TreatmentFacility { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=RehabAid;Username=postgres;Password=Tbmc@1445;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.HasIndex(e => e.CreatorId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Container)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CreationDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Extension).HasMaxLength(8);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Attachment_CreatorId_fkey");
            });

            modelBuilder.Entity<Guardians>(entity =>
            {
                entity.HasIndex(e => e.FacilityId);

                entity.HasIndex(e => e.PatientId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(64);

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Surname).HasMaxLength(64);

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.Guardians)
                    .HasForeignKey(d => d.FacilityId)
                    .HasConstraintName("FacilityId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Guardians)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("PatientId");
            });

            modelBuilder.Entity<MedicineLog>(entity =>
            {
                entity.HasIndex(e => e.CreatorId);

                entity.HasIndex(e => e.PatientId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.PrescriptionLabel)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.MedicineLog)
                    .HasForeignKey(d => d.CreatorId)
                    .HasConstraintName("CreatorId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.MedicineLog)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("PatientId");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasIndex(e => e.FacilityId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(128);

                entity.Property(e => e.CreationDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.EmergencyContact).HasMaxLength(128);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Surname).HasMaxLength(128);

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.FacilityId)
                    .HasConstraintName("FacilityId");
            });

            modelBuilder.Entity<PatientAttentance>(entity =>
            {
                entity.ToTable("PatientAttentance ");

                entity.HasIndex(e => e.CreatorId);

                entity.HasIndex(e => e.PatientId);

                entity.HasIndex(e => e.SpecialistId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Date).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.PatientAttentance)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CreatorId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientAttentance)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("PatientId");

                entity.HasOne(d => d.Specialist)
                    .WithMany(p => p.PatientAttentance)
                    .HasForeignKey(d => d.SpecialistId)
                    .HasConstraintName("SpecialistId");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasIndex(e => e.CreatorId);

                entity.HasIndex(e => e.GuardianId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Description)
                    .HasColumnName("Description ")
                    .HasMaxLength(128);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasDefaultValueSql("''::text");

                entity.Property(e => e.Name).HasMaxLength(64);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''::character varying");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.CreatorId)
                    .HasConstraintName("UserId");

                entity.HasOne(d => d.Guardian)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.GuardianId)
                    .HasConstraintName("GuardianId");
            });

            modelBuilder.Entity<Specialist>(entity =>
            {
                entity.HasIndex(e => e.CreatorId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.FirstName).HasMaxLength(64);

                entity.Property(e => e.PhoneNumber).HasMaxLength(64);

                entity.Property(e => e.Surname).HasMaxLength(64);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Specialist)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CreatorId");
            });

            modelBuilder.Entity<SpecialistAppointment>(entity =>
            {
                entity.HasIndex(e => e.CreatorId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AppointmentDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CreationDate).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.SpecialistAppointment)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CreatorId");
            });

            modelBuilder.Entity<SpecialistReview>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.SpecialistReview)
                    .HasForeignKey(d => d.CreatorId)
                    .HasConstraintName("CreatorId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.SpecialistReview)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PatientId");

                entity.HasOne(d => d.Specialist)
                    .WithMany(p => p.SpecialistReview)
                    .HasForeignKey(d => d.SpecialistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SpecialistId");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasIndex(e => e.CreatorId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(128);

                entity.Property(e => e.CreationDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Email).HasMaxLength(64);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.CreatorId)
                    .HasConstraintName("CreatorId");
            });

            modelBuilder.Entity<TreatmentFacility>(entity =>
            {
                entity.HasIndex(e => e.CreatorId);

                entity.HasIndex(e => e.LogoId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CreatorId).HasColumnName("CreatorId ");

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.TreatmentFacility)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CreatorId");

                entity.HasOne(d => d.Logo)
                    .WithMany(p => p.TreatmentFacility)
                    .HasForeignKey(d => d.LogoId)
                    .HasConstraintName("LogoId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ActivationDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.AuthRecoveryCodes).HasMaxLength(512);

                entity.Property(e => e.AuthenticatorKey).HasMaxLength(128);

                entity.Property(e => e.CreationDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.LastLoginDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LockoutExpiryDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LoginId)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Mobile).HasMaxLength(16);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PasswordHash).HasMaxLength(256);

                entity.Property(e => e.SecurityStamp).HasMaxLength(256);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("PatientId");

                entity.HasOne(d => d.SpecialistNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.SpecialistId)
                    .HasConstraintName("SpecialistId");

                entity.HasOne(d => d.StaffNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("StaffId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
