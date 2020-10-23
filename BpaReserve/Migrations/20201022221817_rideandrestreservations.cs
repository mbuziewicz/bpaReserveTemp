using Microsoft.EntityFrameworkCore.Migrations;

namespace BpaReserve.Migrations
{
    public partial class rideandrestreservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RideReservation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    RideID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideReservation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RideReservation_Ride_RideID",
                        column: x => x.RideID,
                        principalTable: "Ride",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RideReservation_user_UserID",
                        column: x => x.UserID,
                        principalTable: "user",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RideReservation_RideID",
                table: "RideReservation",
                column: "RideID");

            migrationBuilder.CreateIndex(
                name: "IX_RideReservation_UserID",
                table: "RideReservation",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RideReservation");
        }
    }
}
