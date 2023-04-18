using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RehabAid.Data.Migrations
{
    public partial class jug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "PatientId",
            //    table: "Guardians");

            //migrationBuilder.DropIndex(
            //    name: "IX_User_PatientId",
            //    table: "User");

            //migrationBuilder.DropColumn(
            //    name: "PatientId",
            //    table: "User");

            //migrationBuilder.AddColumn<Guid>(
            //    name: "GuardianId",
            //    table: "User",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_User_GuardianId",
            //    table: "User",
            //    column: "GuardianId");

            //migrationBuilder.AddForeignKey(
            //    name: "GuardianId",
            //    table: "User",
            //    column: "GuardianId",
            //    principalTable: "Guardians",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "GuardianId",
                table: "ProgressReport");

            migrationBuilder.DropIndex(
                name: "IX_User_GuardianId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GuardianId",
                table: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                table: "User",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_PatientId",
                table: "User",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "PatientId",
                table: "User",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
