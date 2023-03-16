using Microsoft.EntityFrameworkCore.Migrations;

namespace hellosas.Migrations
{
    public partial class sas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "phoneno",
                table: "stdinfo",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "phoneno",
                table: "stdinfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
