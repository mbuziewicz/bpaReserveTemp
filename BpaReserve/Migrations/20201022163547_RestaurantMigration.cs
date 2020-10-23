using Microsoft.EntityFrameworkCore.Migrations;

namespace BpaReserve.Migrations
{
    public partial class RestaurantMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    RestaurantID = table.Column<int>(nullable: false),
                    RestaurantName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WaitTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.RestaurantID);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "restaurant_reservation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    RestaurantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurant_reservation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_restaurant_reservation_Restaurant_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurant",
                        principalColumn: "RestaurantID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_restaurant_reservation_user_UserID",
                        column: x => x.UserID,
                        principalTable: "user",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_reservation_RestaurantID",
                table: "restaurant_reservation",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_reservation_UserID",
                table: "restaurant_reservation",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "restaurant_reservation");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
