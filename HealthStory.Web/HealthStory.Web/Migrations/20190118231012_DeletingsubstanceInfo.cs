using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthStory.Web.Migrations
{
    public partial class DeletingsubstanceInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SubstanceInfo",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SubstanceInfo");
        }
    }
}
