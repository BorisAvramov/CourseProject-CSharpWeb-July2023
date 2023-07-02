using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class CorrectProgrammingLanguagesForeignKeyConfigurationInApplicantsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_ProgrammingLanguages_TownId",
                table: "Applicants");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 2, 13, 33, 41, 479, DateTimeKind.Utc).AddTicks(6174),
                comment: "This is publish date of job offer",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 2, 13, 14, 33, 213, DateTimeKind.Utc).AddTicks(2490),
                oldComment: "This is publish date of job offer");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_ProgrammingLanguageId",
                table: "Applicants",
                column: "ProgrammingLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_ProgrammingLanguages_ProgrammingLanguageId",
                table: "Applicants",
                column: "ProgrammingLanguageId",
                principalTable: "ProgrammingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_ProgrammingLanguages_ProgrammingLanguageId",
                table: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_ProgrammingLanguageId",
                table: "Applicants");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 2, 13, 14, 33, 213, DateTimeKind.Utc).AddTicks(2490),
                comment: "This is publish date of job offer",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 2, 13, 33, 41, 479, DateTimeKind.Utc).AddTicks(6174),
                oldComment: "This is publish date of job offer");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_ProgrammingLanguages_TownId",
                table: "Applicants",
                column: "TownId",
                principalTable: "ProgrammingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
