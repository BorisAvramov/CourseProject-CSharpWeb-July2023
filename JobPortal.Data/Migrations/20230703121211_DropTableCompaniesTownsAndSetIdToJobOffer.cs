using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class DropTableCompaniesTownsAndSetIdToJobOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompaniesTowns");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 12, 12, 9, 633, DateTimeKind.Utc).AddTicks(4887),
                comment: "This is publish date of job offer",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 3, 11, 4, 17, 198, DateTimeKind.Utc).AddTicks(2542),
                oldComment: "This is publish date of job offer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 11, 4, 17, 198, DateTimeKind.Utc).AddTicks(2542),
                comment: "This is publish date of job offer",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 3, 12, 12, 9, 633, DateTimeKind.Utc).AddTicks(4887),
                oldComment: "This is publish date of job offer");

            migrationBuilder.CreateTable(
                name: "CompaniesTowns",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TownId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesTowns", x => new { x.CompanyId, x.TownId });
                    table.ForeignKey(
                        name: "FK_CompaniesTowns_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompaniesTowns_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "mapping table for many to many relation -> a company could have offices in many towns and many companies could have an office in a town");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesTowns_TownId",
                table: "CompaniesTowns",
                column: "TownId");
        }
    }
}
