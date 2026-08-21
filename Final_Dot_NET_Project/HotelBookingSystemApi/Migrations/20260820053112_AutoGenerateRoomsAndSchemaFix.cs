using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AutoGenerateRoomsAndSchemaFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRooms_Reservations_ReservationId1",
                table: "ReservationRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRooms_Rooms_RoomId",
                table: "ReservationRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRooms_Rooms_RoomId1",
                table: "ReservationRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomerId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CustomerId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_ReservationRooms_ReservationId1",
                table: "ReservationRooms");

            migrationBuilder.DropIndex(
                name: "IX_ReservationRooms_RoomId1",
                table: "ReservationRooms");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "MaxOccupancy",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Check_In_Date",
                table: "ReservationRooms");

            migrationBuilder.DropColumn(
                name: "Check_Out_Date",
                table: "ReservationRooms");

            migrationBuilder.DropColumn(
                name: "ReservationId1",
                table: "ReservationRooms");

            migrationBuilder.DropColumn(
                name: "RoomId1",
                table: "ReservationRooms");

            migrationBuilder.AddColumn<string>(
                name: "Room_Type",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Standard");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Available");

            migrationBuilder.AddColumn<DateTime>(
                name: "Check_In_Date",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Check_Out_Date",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<decimal>(
                name: "Total_Ammount",
                table: "Billing",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PayementDate",
                table: "Billing",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId_Room_Number",
                table: "Rooms",
                columns: new[] { "HotelId", "Room_Number" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRooms_Rooms_RoomId",
                table: "ReservationRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRooms_Rooms_RoomId",
                table: "ReservationRooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HotelId_Room_Number",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Room_Type",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Check_In_Date",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Check_Out_Date",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxOccupancy",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Check_In_Date",
                table: "ReservationRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Check_Out_Date",
                table: "ReservationRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ReservationId1",
                table: "ReservationRooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId1",
                table: "ReservationRooms",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Total_Ammount",
                table: "Billing",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PayementDate",
                table: "Billing",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId1",
                table: "Reservations",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRooms_ReservationId1",
                table: "ReservationRooms",
                column: "ReservationId1");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRooms_RoomId1",
                table: "ReservationRooms",
                column: "RoomId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRooms_Reservations_ReservationId1",
                table: "ReservationRooms",
                column: "ReservationId1",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRooms_Rooms_RoomId",
                table: "ReservationRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRooms_Rooms_RoomId1",
                table: "ReservationRooms",
                column: "RoomId1",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomerId1",
                table: "Reservations",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
