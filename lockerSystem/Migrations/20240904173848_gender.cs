using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lockerSystem.Migrations
{
    public partial class gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "tblUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "tblBuilding",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gender",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "tblBuilding");
        }
    }
}
