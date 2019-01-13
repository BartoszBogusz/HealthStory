using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthStory.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    AppUserId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Login = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.AppUserId);
                });

            migrationBuilder.CreateTable(
                name: "SubstanceInfo",
                columns: table => new
                {
                    SubstanceDefinitionId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(nullable: true),
                    Max = table.Column<decimal>(nullable: false),
                    Min = table.Column<decimal>(nullable: false),
                    Unit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubstanceInfo", x => x.SubstanceDefinitionId);
                });

            migrationBuilder.CreateTable(
                name: "BloodTests",
                columns: table => new
                {
                    BloodTestId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    AppUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTests", x => x.BloodTestId);
                    table.ForeignKey(
                        name: "FK_BloodTests_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodTestsSubstances",
                columns: table => new
                {
                    BloodTestSubstanceId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Value = table.Column<int>(nullable: false),
                    BloodTestId = table.Column<int>(nullable: false),
                    SubstanceInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTestsSubstances", x => x.BloodTestSubstanceId);
                    table.ForeignKey(
                        name: "FK_BloodTestsSubstances_BloodTests_BloodTestId",
                        column: x => x.BloodTestId,
                        principalTable: "BloodTests",
                        principalColumn: "BloodTestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BloodTestsSubstances_SubstanceInfo_SubstanceInfoId",
                        column: x => x.SubstanceInfoId,
                        principalTable: "SubstanceInfo",
                        principalColumn: "SubstanceDefinitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodTests_AppUserId",
                table: "BloodTests",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTestsSubstances_BloodTestId",
                table: "BloodTestsSubstances",
                column: "BloodTestId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTestsSubstances_SubstanceInfoId",
                table: "BloodTestsSubstances",
                column: "SubstanceInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodTestsSubstances");

            migrationBuilder.DropTable(
                name: "BloodTests");

            migrationBuilder.DropTable(
                name: "SubstanceInfo");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
