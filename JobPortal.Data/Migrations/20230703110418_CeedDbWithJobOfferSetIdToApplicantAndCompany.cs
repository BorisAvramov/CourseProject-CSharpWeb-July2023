using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class CeedDbWithJobOfferSetIdToApplicantAndCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 49, 19, 429, DateTimeKind.Utc).AddTicks(5256),
                oldComment: "This is publish date of job offer");

            migrationBuilder.InsertData(
                table: "JobOffers",
                columns: new[] { "Id", "CompanyId", "Description", "JobTypeId", "LevelId", "Name", "ProgrammingLanguageId", "TownId" },
                values: new object[] { new Guid("fea40df4-a755-4a4e-8185-34eb17d90ea1"), new Guid("9ac7482a-10ce-4d60-9d3b-4ccf2724887b"), "As a .NET Developer your primary focus will be the development of software components using C# (.NET Core/.NET Standard wirh.The role of a . NET developer is to develop, improve, troubleshoot, and maintain computer software applications. You are expected to plan, design, and develop new feature functionality of a software application, and identify, debug, and troubleshoot defects.", 2, 1, "C# .NET Developer", 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("fea40df4-a755-4a4e-8185-34eb17d90ea1"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 49, 19, 429, DateTimeKind.Utc).AddTicks(5256),
                comment: "This is publish date of job offer",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 3, 11, 4, 17, 198, DateTimeKind.Utc).AddTicks(2542),
                oldComment: "This is publish date of job offer");
        }
    }
}
