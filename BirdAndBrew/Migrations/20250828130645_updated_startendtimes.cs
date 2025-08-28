using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdAndBrew.Migrations
{
    /// <inheritdoc />
    public partial class updated_startendtimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReservationDateTime",
                table: "Reservations",
                newName: "ReservationStartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationEndTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationEndTime",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ReservationStartTime",
                table: "Reservations",
                newName: "ReservationDateTime");
        }
    }
}
