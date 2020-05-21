using Microsoft.EntityFrameworkCore.Migrations;

namespace city_west_water_coding_test.Migrations
{
    public partial class UpdateStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Student",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Student",
                newName: "Name");
        }
    }
}
