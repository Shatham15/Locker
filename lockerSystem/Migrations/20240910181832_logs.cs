using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lockerSystem.Migrations
{
    public partial class logs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblBooking_tblBookingState_BookingStateId",
                table: "tblBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_tblBooking_tblLocker_LockerId",
                table: "tblBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_tblBooking_tblSemster_SemsterId",
                table: "tblBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFloor_tblBuilding_BuildingId",
                table: "tblFloor");

            migrationBuilder.DropForeignKey(
                name: "FK_tblLocker_tblFloor_FloorId",
                table: "tblLocker");

            migrationBuilder.DropForeignKey(
                name: "FK_tblLocker_tblLockerState_LockerStateId",
                table: "tblLocker");

            migrationBuilder.DropForeignKey(
                name: "FK_tblPermission_tblRole_RoleId",
                table: "tblPermission");

            migrationBuilder.CreateTable(
                name: "BuildingLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    operationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    generatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Building_Id = table.Column<int>(type: "int", nullable: false),
                    additionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FloorLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    operationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    generatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Floor_Id = table.Column<int>(type: "int", nullable: false),
                    additionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lockerLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    operationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    generatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Locker_Id = table.Column<int>(type: "int", nullable: false),
                    additionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lockerLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lockerStateLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    operationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    generatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Locker_state_Id = table.Column<int>(type: "int", nullable: false),
                    additionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lockerStateLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permissionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    generatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    generatedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    operationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Permission_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SemesterLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    operationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    generatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Semester_Id = table.Column<int>(type: "int", nullable: false),
                    additionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterLog", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_tblBooking_tblBookingState_BookingStateId",
                table: "tblBooking",
                column: "BookingStateId",
                principalTable: "tblBookingState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblBooking_tblLocker_LockerId",
                table: "tblBooking",
                column: "LockerId",
                principalTable: "tblLocker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblBooking_tblSemster_SemsterId",
                table: "tblBooking",
                column: "SemsterId",
                principalTable: "tblSemster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFloor_tblBuilding_BuildingId",
                table: "tblFloor",
                column: "BuildingId",
                principalTable: "tblBuilding",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblLocker_tblFloor_FloorId",
                table: "tblLocker",
                column: "FloorId",
                principalTable: "tblFloor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblLocker_tblLockerState_LockerStateId",
                table: "tblLocker",
                column: "LockerStateId",
                principalTable: "tblLockerState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblPermission_tblRole_RoleId",
                table: "tblPermission",
                column: "RoleId",
                principalTable: "tblRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblBooking_tblBookingState_BookingStateId",
                table: "tblBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_tblBooking_tblLocker_LockerId",
                table: "tblBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_tblBooking_tblSemster_SemsterId",
                table: "tblBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFloor_tblBuilding_BuildingId",
                table: "tblFloor");

            migrationBuilder.DropForeignKey(
                name: "FK_tblLocker_tblFloor_FloorId",
                table: "tblLocker");

            migrationBuilder.DropForeignKey(
                name: "FK_tblLocker_tblLockerState_LockerStateId",
                table: "tblLocker");

            migrationBuilder.DropForeignKey(
                name: "FK_tblPermission_tblRole_RoleId",
                table: "tblPermission");

            migrationBuilder.DropTable(
                name: "BuildingLog");

            migrationBuilder.DropTable(
                name: "FloorLog");

            migrationBuilder.DropTable(
                name: "lockerLog");

            migrationBuilder.DropTable(
                name: "lockerStateLog");

            migrationBuilder.DropTable(
                name: "PermissionLog");

            migrationBuilder.DropTable(
                name: "SemesterLog");

            migrationBuilder.AddForeignKey(
                name: "FK_tblBooking_tblBookingState_BookingStateId",
                table: "tblBooking",
                column: "BookingStateId",
                principalTable: "tblBookingState",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblBooking_tblLocker_LockerId",
                table: "tblBooking",
                column: "LockerId",
                principalTable: "tblLocker",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblBooking_tblSemster_SemsterId",
                table: "tblBooking",
                column: "SemsterId",
                principalTable: "tblSemster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFloor_tblBuilding_BuildingId",
                table: "tblFloor",
                column: "BuildingId",
                principalTable: "tblBuilding",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblLocker_tblFloor_FloorId",
                table: "tblLocker",
                column: "FloorId",
                principalTable: "tblFloor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblLocker_tblLockerState_LockerStateId",
                table: "tblLocker",
                column: "LockerStateId",
                principalTable: "tblLockerState",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblPermission_tblRole_RoleId",
                table: "tblPermission",
                column: "RoleId",
                principalTable: "tblRole",
                principalColumn: "Id");
        }
    }
}
