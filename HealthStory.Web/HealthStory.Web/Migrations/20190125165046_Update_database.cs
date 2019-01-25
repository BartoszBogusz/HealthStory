using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthStory.Web.Migrations
{
    public partial class Update_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodTestsSubstances");

            migrationBuilder.DropTable(
                name: "BloodTests");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AppUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "BloodTestsInfo",
                columns: table => new
                {
                    BloodTestInfoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTestsInfo", x => x.BloodTestInfoId);
                });

            migrationBuilder.CreateTable(
                name: "BloodTestsSubstancesInfo",
                columns: table => new
                {
                    BloodTestInfoId = table.Column<int>(nullable: false),
                    SubstanceInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTestsSubstancesInfo", x => new { x.BloodTestInfoId, x.SubstanceInfoId });
                    table.ForeignKey(
                        name: "FK_BloodTestsSubstancesInfo_BloodTestsInfo_BloodTestInfoId",
                        column: x => x.BloodTestInfoId,
                        principalTable: "BloodTestsInfo",
                        principalColumn: "BloodTestInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BloodTestsSubstancesInfo_SubstanceInfo_SubstanceInfoId",
                        column: x => x.SubstanceInfoId,
                        principalTable: "SubstanceInfo",
                        principalColumn: "SubstanceInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodTestsSubstancesInfo_SubstanceInfoId",
                table: "BloodTestsSubstancesInfo",
                column: "SubstanceInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodTestsSubstancesInfo");

            migrationBuilder.DropTable(
                name: "BloodTestsInfo");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AppUsers");

            migrationBuilder.CreateTable(
                name: "BloodTests",
                columns: table => new
                {
                    BloodTestId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppUserId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BloodTestId = table.Column<int>(nullable: false),
                    SubstanceInfoId = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
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
                        principalColumn: "SubstanceInfoId",
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
    }
}
