using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthStory.Web.Migrations
{
    public partial class addguidpropertytoAppUserBloodTestValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AppUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AppUserBloodTestValues",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "AppUserBloodTestValues");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AppUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "AppUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AppUsers",
                nullable: true);
        }
    }
}
