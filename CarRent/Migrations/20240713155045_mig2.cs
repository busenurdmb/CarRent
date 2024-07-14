using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRent.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_BrandID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Cars_CarID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Cars_CarID1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CarID1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CarID1",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_BrandID",
                table: "Cars",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "BrandID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Cars_CarID",
                table: "Reservations",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_BrandID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Cars_CarID",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "CarID1",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarID1",
                table: "Reservations",
                column: "CarID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_BrandID",
                table: "Cars",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "BrandID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Cars_CarID",
                table: "Reservations",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Cars_CarID1",
                table: "Reservations",
                column: "CarID1",
                principalTable: "Cars",
                principalColumn: "CarID");
        }
    }
}
