using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthStory.Web.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubDefs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(nullable: true),
                    Max = table.Column<int>(nullable: false),
                    Min = table.Column<int>(nullable: false),
                    Unit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDefs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Login = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "BloodTests",
                columns: table => new
                {
                    BloodTestId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    UserId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTests", x => x.BloodTestId);
                    table.ForeignKey(
                        name: "FK_BloodTests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BloodTestsSubstances",
                columns: table => new
                {
                    BloodTestSubstanceId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Value = table.Column<int>(nullable: false),
                    BloodTestId = table.Column<int>(nullable: true),
                    SubDefId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTestsSubstances", x => x.BloodTestSubstanceId);
                    table.ForeignKey(
                        name: "FK_BloodTestsSubstances_BloodTests_BloodTestId",
                        column: x => x.BloodTestId,
                        principalTable: "BloodTests",
                        principalColumn: "BloodTestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BloodTestsSubstances_SubDefs_SubDefId",
                        column: x => x.SubDefId,
                        principalTable: "SubDefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodTests_UserId",
                table: "BloodTests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTestsSubstances_BloodTestId",
                table: "BloodTestsSubstances",
                column: "BloodTestId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTestsSubstances_SubDefId",
                table: "BloodTestsSubstances",
                column: "SubDefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodTestsSubstances");

            migrationBuilder.DropTable(
                name: "BloodTests");

            migrationBuilder.DropTable(
                name: "SubDefs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
