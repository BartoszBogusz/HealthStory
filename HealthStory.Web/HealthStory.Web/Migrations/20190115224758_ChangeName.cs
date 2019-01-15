using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthStory.Web.Migrations
{
    public partial class ChangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubstanceDefinitionId",
                table: "SubstanceInfo",
                newName: "SubstanceInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubstanceInfoId",
                table: "SubstanceInfo",
                newName: "SubstanceDefinitionId");
        }
    }
}
