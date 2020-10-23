using Microsoft.EntityFrameworkCore.Migrations;

namespace BpaReserve.Migrations
{
    public partial class migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RideImageUrl",
                table: "Ride",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RideImageUrl",
                table: "Ride");
        }
    }
}
