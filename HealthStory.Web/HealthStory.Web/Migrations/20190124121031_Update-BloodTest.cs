using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthStory.Web.Migrations
{
    public partial class UpdateBloodTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BloodTests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BloodTests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "BloodTests");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BloodTests");
        }
    }
}
