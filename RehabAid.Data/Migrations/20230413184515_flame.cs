using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RehabAid.Data.Migrations
{
    public partial class flame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "PatientId",
                table: "Guardians");

            migrationBuilder.DropForeignKey(
                name: "CreatorId",
                table: "MedicineLog");

            //migrationBuilder.DropTable(
            //    name: "ProgressReports");

            //migrationBuilder.CreateTable(
            //    name: "ProgressReport",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        GuardianId = table.Column<Guid>(nullable: false),
            //        PatientId = table.Column<Guid>(nullable: false),
            //        TherapyReview = table.Column<string>(nullable: true),
            //        CreatorId = table.Column<Guid>(nullable: true),
            //        CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProgressReport", x => x.Id);
            //        table.ForeignKey(
            //            name: "CreatorId",
            //            column: x => x.CreatorId,
            //            principalTable: "User",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "GuardianId",
            //            column: x => x.GuardianId,
            //            principalTable: "Guardians",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "PatientId",
            //            column: x => x.PatientId,
            //            principalTable: "Patient",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProgressReport_CreatorId",
            //    table: "ProgressReport",
            //    column: "CreatorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProgressReport_GuardianId",
            //    table: "ProgressReport",
            //    column: "GuardianId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProgressReport_PatientId",
            //    table: "ProgressReport",
            //    column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "PatientId",
                table: "Guardians");

            migrationBuilder.DropForeignKey(
                name: "CreatorId",
                table: "MedicineLog");

            //migrationBuilder.DropTable(
            //    name: "ProgressReport");

            migrationBuilder.CreateTable(
                name: "ProgressReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    GuardianId = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    TherapyReview = table.Column<string>(type: "text", nullable: true)
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

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProgressReports_CreatorId",
            //    table: "ProgressReports",
            //    column: "CreatorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProgressReports_GuardianId",
            //    table: "ProgressReports",
            //    column: "GuardianId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProgressReports_PatientId",
            //    table: "ProgressReports",
            //    column: "PatientId");
        }
    }
}
