using Microsoft.EntityFrameworkCore.Migrations;

namespace RehabAid.Data.Migrations
{
    public partial class wrath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxLimit",
                table: "TreatmentFacility",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "MaxLimit",
            //    table: "TreatmentFacility");
        }
    }
}
