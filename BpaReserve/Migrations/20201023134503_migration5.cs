using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BpaReserve.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAndTime",
                table: "RideReservation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAndTime",
                table: "restaurant_reservation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAndTime",
                table: "RideReservation");

            migrationBuilder.DropColumn(
                name: "DateAndTime",
                table: "restaurant_reservation");
        }
    }
}
