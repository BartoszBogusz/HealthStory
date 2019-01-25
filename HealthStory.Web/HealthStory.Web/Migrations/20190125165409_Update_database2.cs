using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthStory.Web.Migrations
{
    public partial class Update_database2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BloodTestsInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BloodTestsInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "BloodTestsInfo");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BloodTestsInfo");
        }
    }
}
