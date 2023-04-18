using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RehabAid.Data.Migrations
{
    public partial class dark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.AddColumn<Guid>(
                name: "MedicineLogId",
                table: "ProgressReport",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Prescription",
                table: "ProgressReport",
                maxLength: 64,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProgressReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GuardianId = table.Column<Guid>(nullable: false),
                    PatientId = table.Column<Guid>(nullable: false),
                    TherapyReview = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressReports", x => x.Id);
                    table.ForeignKey(
                        name: "CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "GuardianId",
                        column: x => x.GuardianId,
                        principalTable: "Guardians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgressReport_MedicineLogId",
                table: "ProgressReport",
                column: "MedicineLogId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressReports_CreatorId",
                table: "ProgressReports",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressReports_GuardianId",
                table: "ProgressReports",
                column: "GuardianId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressReports_PatientId",
                table: "ProgressReports",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "MedicineLogId",
                table: "ProgressReport",
                column: "MedicineLogId",
                principalTable: "MedicineLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropForeignKey(
                name: "GuardianId",
                table: "ProgressReport");

         

            migrationBuilder.DropTable(
                name: "ProgressReports");

            migrationBuilder.DropIndex(
                name: "IX_ProgressReport_MedicineLogId",
                table: "ProgressReport");

            migrationBuilder.DropColumn(
                name: "MedicineLogId",
                table: "ProgressReport");

            migrationBuilder.DropColumn(
                name: "Prescription",
                table: "ProgressReport");
        }
    }
}
