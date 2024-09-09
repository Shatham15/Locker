using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lockerSystem.Migrations
{
    public partial class addfirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bookingStatues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Booking_Id = table.Column<int>(type: "int", nullable: false),
                    modifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblBookingState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBookingState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblBuilding",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    no = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBuilding", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblLockerState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    stateAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stateEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLockerState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblManagement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RoleNameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblSemster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    startSemster = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endSemster = table.Column<DateTime>(type: "datetime2", nullable: false),
                    semsterNameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    semsterNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tblSemsterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSemster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblSemster_tblSemster_tblSemsterId",
                        column: x => x.tblSemsterId,
                        principalTable: "tblSemster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFloor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    no = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFloor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblFloor_tblBuilding_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "tblBuilding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPermission_tblRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tblRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tblLocker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    no = table.Column<int>(type: "int", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false),
                    LockerStateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLocker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblLocker_tblFloor_FloorId",
                        column: x => x.FloorId,
                        principalTable: "tblFloor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tblLocker_tblLockerState_LockerStateId",
                        column: x => x.LockerStateId,
                        principalTable: "tblLockerState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tblBooking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    bokingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingStateId = table.Column<int>(type: "int", nullable: false),
                    LockerId = table.Column<int>(type: "int", nullable: false),
                    SemsterId = table.Column<int>(type: "int", nullable: false),
                    rejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    colegename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    floornumer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblBooking_tblBookingState_BookingStateId",
                        column: x => x.BookingStateId,
                        principalTable: "tblBookingState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tblBooking_tblLocker_LockerId",
                        column: x => x.LockerId,
                        principalTable: "tblLocker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tblBooking_tblSemster_SemsterId",
                        column: x => x.SemsterId,
                        principalTable: "tblSemster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblBooking_BookingStateId",
                table: "tblBooking",
                column: "BookingStateId");

            migrationBuilder.CreateIndex(
                name: "IX_tblBooking_LockerId",
                table: "tblBooking",
                column: "LockerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblBooking_SemsterId",
                table: "tblBooking",
                column: "SemsterId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFloor_BuildingId",
                table: "tblFloor",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLocker_FloorId",
                table: "tblLocker",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLocker_LockerStateId",
                table: "tblLocker",
                column: "LockerStateId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPermission_RoleId",
                table: "tblPermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSemster_tblSemsterId",
                table: "tblSemster",
                column: "tblSemsterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingLog");

            migrationBuilder.DropTable(
                name: "tblBooking");

            migrationBuilder.DropTable(
                name: "tblManagement");

            migrationBuilder.DropTable(
                name: "tblPermission");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblBookingState");

            migrationBuilder.DropTable(
                name: "tblLocker");

            migrationBuilder.DropTable(
                name: "tblSemster");

            migrationBuilder.DropTable(
                name: "tblRole");

            migrationBuilder.DropTable(
                name: "tblFloor");

            migrationBuilder.DropTable(
                name: "tblLockerState");

            migrationBuilder.DropTable(
                name: "tblBuilding");
        }
    }
}
