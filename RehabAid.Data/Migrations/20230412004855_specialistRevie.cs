using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RehabAid.Data.Migrations
{
    public partial class specialistRevie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreatmentFacility",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 128, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    TypeId = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(name: "CreatorId ", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LogoId = table.Column<Guid>(nullable: true),
                    AttachmentJson = table.Column<string>(nullable: true),
                    ProgramId = table.Column<int>(nullable: true),
                    ServiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentFacility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Surname = table.Column<string>(maxLength: 128, nullable: true),
                    Age = table.Column<int>(nullable: true),
                    FacilityId = table.Column<Guid>(nullable: true),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    Address = table.Column<string>(maxLength: 128, nullable: true),
                    EmergencyContact = table.Column<string>(maxLength: 128, nullable: true),
                    GenderId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 128, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "TreatmentFacility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Guardians",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 64, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 16, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    Relationship = table.Column<int>(nullable: true),
                    FacilityId = table.Column<Guid>(nullable: true),
                    PatientId = table.Column<Guid>(nullable: true),
                    Surname = table.Column<string>(maxLength: 64, nullable: true),
                    Address = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardians", x => x.Id);
                    table.ForeignKey(
                        name: "FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "TreatmentFacility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GuardianId = table.Column<Guid>(nullable: true),
                    FacilityId = table.Column<Guid>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(name: "Description ", maxLength: 128, nullable: true),
                    Status = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Email = table.Column<string>(nullable: false, defaultValueSql: "''::text"),
                    PhoneNumber = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "''::character varying")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "GuardianId",
                        column: x => x.GuardianId,
                        principalTable: "Guardians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicineLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    PatientId = table.Column<Guid>(nullable: true),
                    DateIssued = table.Column<Guid>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PrescriptionLabel = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineLog", x => x.Id);
                    table.ForeignKey(
                        name: "PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientAttentance ",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PatientId = table.Column<Guid>(nullable: true),
                    SpecialistId = table.Column<Guid>(nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAttentance ", x => x.Id);
                    table.ForeignKey(
                        name: "PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialistReview",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SpecialistId = table.Column<Guid>(nullable: false),
                    PatientId = table.Column<Guid>(nullable: false),
                    Review = table.Column<string>(nullable: true),
                    SentimentId = table.Column<int>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TimeOfSessionId = table.Column<int>(nullable: true),
                    AgeOfPatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialistReview", x => x.Id);
                    table.ForeignKey(
                        name: "PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    LoginId = table.Column<string>(maxLength: 32, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    Mobile = table.Column<string>(maxLength: 16, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsEmailConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(maxLength: 256, nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AuthenticatorKey = table.Column<string>(maxLength: 128, nullable: true),
                    AuthRecoveryCodes = table.Column<string>(maxLength: 512, nullable: true),
                    TwoFactorAuthEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LockoutExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActivationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsMobileConfirmed = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PatientId = table.Column<Guid>(nullable: true),
                    StaffId = table.Column<Guid>(nullable: true),
                    SpecialistId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    UniqueId = table.Column<Guid>(nullable: true),
                    Container = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NotesJson = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                    table.ForeignKey(
                        name: "Attachment_CreatorId_fkey",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specialist",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 64, nullable: true),
                    Surname = table.Column<string>(maxLength: 64, nullable: true),
                    DOB = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 64, nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(nullable: true),
                    SpecialtyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialist", x => x.Id);
                    table.ForeignKey(
                        name: "CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialistAppointment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SpecialistId = table.Column<Guid>(nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialistAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 128, nullable: false),
                    DOB = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 64, nullable: false),
                    Surname = table.Column<string>(maxLength: 64, nullable: false),
                    Email = table.Column<string>(maxLength: 64, nullable: true),
                    RoleId = table.Column<int>(nullable: true),
                    Address = table.Column<string>(maxLength: 128, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_CreatorId",
                table: "Attachment",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_FacilityId",
                table: "Guardians",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_PatientId",
                table: "Guardians",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineLog_CreatorId",
                table: "MedicineLog",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineLog_PatientId",
                table: "MedicineLog",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_FacilityId",
                table: "Patient",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAttentance _CreatorId",
                table: "PatientAttentance ",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAttentance _PatientId",
                table: "PatientAttentance ",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAttentance _SpecialistId",
                table: "PatientAttentance ",
                column: "SpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CreatorId",
                table: "Reservation",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_GuardianId",
                table: "Reservation",
                column: "GuardianId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialist_CreatorId",
                table: "Specialist",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialistAppointment_CreatorId",
                table: "SpecialistAppointment",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialistReview_CreatorId",
                table: "SpecialistReview",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialistReview_PatientId",
                table: "SpecialistReview",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialistReview_SpecialistId",
                table: "SpecialistReview",
                column: "SpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_CreatorId",
                table: "Staff",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentFacility_CreatorId ",
                table: "TreatmentFacility",
                column: "CreatorId ");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentFacility_LogoId",
                table: "TreatmentFacility",
                column: "LogoId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PatientId",
                table: "User",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SpecialistId",
                table: "User",
                column: "SpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_User_StaffId",
                table: "User",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "CreatorId",
                table: "TreatmentFacility",
                column: "CreatorId ",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "LogoId",
                table: "TreatmentFacility",
                column: "LogoId",
                principalTable: "Attachment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "UserId",
                table: "Reservation",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "CreatorId",
                table: "MedicineLog",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "CreatorId",
                table: "PatientAttentance ",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "SpecialistId",
                table: "PatientAttentance ",
                column: "SpecialistId",
                principalTable: "Specialist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "CreatorId",
                table: "SpecialistReview",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "SpecialistId",
                table: "SpecialistReview",
                column: "SpecialistId",
                principalTable: "Specialist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "SpecialistId",
                table: "User",
                column: "SpecialistId",
                principalTable: "Specialist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "StaffId",
                table: "User",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Attachment_CreatorId_fkey",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "CreatorId",
                table: "Specialist");

            migrationBuilder.DropForeignKey(
                name: "CreatorId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "CreatorId",
                table: "TreatmentFacility");

            migrationBuilder.DropTable(
                name: "MedicineLog");

            migrationBuilder.DropTable(
                name: "PatientAttentance ");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "SpecialistAppointment");

            migrationBuilder.DropTable(
                name: "SpecialistReview");

            migrationBuilder.DropTable(
                name: "Guardians");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Specialist");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "TreatmentFacility");

            migrationBuilder.DropTable(
                name: "Attachment");
        }
    }
}
