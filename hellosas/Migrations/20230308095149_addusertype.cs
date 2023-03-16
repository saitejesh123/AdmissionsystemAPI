using Microsoft.EntityFrameworkCore.Migrations;

namespace hellosas.Migrations
{
    public partial class addusertype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_admissioninfo_stdinfo_stdinfostdid",
                table: "admissioninfo");

            migrationBuilder.DropIndex(
                name: "IX_admissioninfo_stdinfostdid",
                table: "admissioninfo");

            migrationBuilder.DropColumn(
                name: "stdinfostdid",
                table: "admissioninfo");

            migrationBuilder.AlterColumn<string>(
                name: "stdname",
                table: "stdinfo",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "stdinfo",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "stdinfo",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "confirm_password",
                table: "stdinfo",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "stdinfo",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usertype",
                table: "stdinfo",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_admissioninfo_studid",
                table: "admissioninfo",
                column: "studid");

            migrationBuilder.AddForeignKey(
                name: "FK_admissioninfo_stdinfo_studid",
                table: "admissioninfo",
                column: "studid",
                principalTable: "stdinfo",
                principalColumn: "stdid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_admissioninfo_stdinfo_studid",
                table: "admissioninfo");

            migrationBuilder.DropIndex(
                name: "IX_admissioninfo_studid",
                table: "admissioninfo");

            migrationBuilder.DropColumn(
                name: "usertype",
                table: "stdinfo");

            migrationBuilder.AlterColumn<string>(
                name: "stdname",
                table: "stdinfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "stdinfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "stdinfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "confirm_password",
                table: "stdinfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "stdinfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "stdinfostdid",
                table: "admissioninfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_admissioninfo_stdinfostdid",
                table: "admissioninfo",
                column: "stdinfostdid");

            migrationBuilder.AddForeignKey(
                name: "FK_admissioninfo_stdinfo_stdinfostdid",
                table: "admissioninfo",
                column: "stdinfostdid",
                principalTable: "stdinfo",
                principalColumn: "stdid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
