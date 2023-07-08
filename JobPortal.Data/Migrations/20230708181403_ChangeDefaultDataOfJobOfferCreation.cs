using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class ChangeDefaultDataOfJobOfferCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 8, 18, 14, 0, 943, DateTimeKind.Utc).AddTicks(6617),
                comment: "This is publish date of job offer",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 3, 12, 29, 12, 451, DateTimeKind.Utc).AddTicks(8400),
                oldComment: "This is publish date of job offer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 12, 29, 12, 451, DateTimeKind.Utc).AddTicks(8400),
                comment: "This is publish date of job offer",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 8, 18, 14, 0, 943, DateTimeKind.Utc).AddTicks(6617),
                oldComment: "This is publish date of job offer");
        }
    }
}
