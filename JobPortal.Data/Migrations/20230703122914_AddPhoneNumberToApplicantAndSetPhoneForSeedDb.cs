using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class AddPhoneNumberToApplicantAndSetPhoneForSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2023, 7, 3, 12, 12, 9, 633, DateTimeKind.Utc).AddTicks(4887),
                oldComment: "This is publish date of job offer");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Applicants",
                keyColumn: "Id",
                keyValue: new Guid("4e2a1953-bab0-4614-9279-f89c50448ed8"),
                column: "Phone",
                value: "+359666666666");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Applicants");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 12, 12, 9, 633, DateTimeKind.Utc).AddTicks(4887),
                comment: "This is publish date of job offer",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 3, 12, 29, 12, 451, DateTimeKind.Utc).AddTicks(8400),
                oldComment: "This is publish date of job offer");
        }
    }
}
