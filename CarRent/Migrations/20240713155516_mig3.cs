using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRent.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "CarID1",
               table: "Reservations");
          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarID2",
                table: "Reservations");
        }
    }
}
