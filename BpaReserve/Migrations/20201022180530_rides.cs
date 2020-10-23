using Microsoft.EntityFrameworkCore.Migrations;

namespace BpaReserve.Migrations
{
    public partial class rides : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ride",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    RideID = table.Column<int>(nullable: false),
                    RideName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WaitTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ride", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ride");
        }
    }
}
