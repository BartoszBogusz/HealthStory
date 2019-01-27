using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthStory.Web.Migrations
{
    public partial class create_AppUSerBloodTesyValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUserBloodTestValues",
                columns: table => new
                {
                    AppUserBloodTestValueId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppUserId = table.Column<int>(nullable: false),
                    SubstanceInfoId = table.Column<int>(nullable: false),
                    BloodTestInfoId = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserBloodTestValues", x => x.AppUserBloodTestValueId);
                    table.ForeignKey(
                        name: "FK_AppUserBloodTestValues_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserBloodTestValues_BloodTestsInfo_BloodTestInfoId",
                        column: x => x.BloodTestInfoId,
                        principalTable: "BloodTestsInfo",
                        principalColumn: "BloodTestInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserBloodTestValues_SubstanceInfo_SubstanceInfoId",
                        column: x => x.SubstanceInfoId,
                        principalTable: "SubstanceInfo",
                        principalColumn: "SubstanceInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserBloodTestValues_AppUserId",
                table: "AppUserBloodTestValues",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserBloodTestValues_BloodTestInfoId",
                table: "AppUserBloodTestValues",
                column: "BloodTestInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserBloodTestValues_SubstanceInfoId",
                table: "AppUserBloodTestValues",
                column: "SubstanceInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserBloodTestValues");
        }
    }
}
