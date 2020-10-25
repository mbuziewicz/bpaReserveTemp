using Microsoft.EntityFrameworkCore.Migrations;

namespace BpaReserve.Migrations
{
    public partial class newmigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RideReservation_user_UserID",
                table: "RideReservation");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "RideReservation",
                newName: "userID");

            migrationBuilder.RenameIndex(
                name: "IX_RideReservation_UserID",
                table: "RideReservation",
                newName: "IX_RideReservation_userID");

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                table: "RideReservation",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "NewUserID",
                table: "RideReservation",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RideReservation_user_userID",
                table: "RideReservation",
                column: "userID",
                principalTable: "user",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RideReservation_user_userID",
                table: "RideReservation");

            migrationBuilder.DropColumn(
                name: "NewUserID",
                table: "RideReservation");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "RideReservation",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_RideReservation_userID",
                table: "RideReservation",
                newName: "IX_RideReservation_UserID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "RideReservation",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RideReservation_user_UserID",
                table: "RideReservation",
                column: "UserID",
                principalTable: "user",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
