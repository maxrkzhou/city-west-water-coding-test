using Microsoft.EntityFrameworkCore.Migrations;

namespace city_west_water_coding_test.Migrations
{
    public partial class RenameStudentColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Student",
                newName: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Student",
                newName: "Surname");
        }
    }
}
