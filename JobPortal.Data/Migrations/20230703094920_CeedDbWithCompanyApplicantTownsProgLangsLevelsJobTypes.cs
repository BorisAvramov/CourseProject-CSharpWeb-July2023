using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class CeedDbWithCompanyApplicantTownsProgLangsLevelsJobTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 49, 19, 429, DateTimeKind.Utc).AddTicks(5256),
                comment: "This is publish date of job offer",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 2, 13, 33, 41, 479, DateTimeKind.Utc).AddTicks(6174),
                oldComment: "This is publish date of job offer");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Description", "ImageUrl", "Name", "Phone" },
                values: new object[] { new Guid("9ac7482a-10ce-4d60-9d3b-4ccf2724887b"), "78 Alexander Malinov Blvd., fl. 1", new Guid("90489bf2-b2d3-40d9-893a-bd907ed03a98"), "Software University Ltd. is a private educational institution for practical training of programmers and IT specialists.", "~/img/topEmlpoyers/SoftUni.png", "Software University", "+359111111111" });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1, "Office" },
                    { 2, "Remote" },
                    { 3, "Hybrid" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Junior" },
                    { 2, "Mid" },
                    { 3, "Senior" }
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "~/img/programmingLanguages/icons8-c-48.png", "C#" },
                    { 2, "~/img/programmingLanguages/icons8-js-48.png", "JS" },
                    { 3, "~/img/programmingLanguages/icons8-python-48.png", "Python" },
                    { 4, "~/img/programmingLanguages/icons8-php-40.png", "PHP" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sofia" },
                    { 2, "Varna" },
                    { 3, "Burgas" },
                    { 4, "Plovdiv" },
                    { 5, "Ruse" },
                    { 6, "Stara Zagora" }
                });

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "ImgUrl", "LastName", "LevelId", "ProgrammingLanguageId", "TownId" },
                values: new object[] { new Guid("4e2a1953-bab0-4614-9279-f89c50448ed8"), new Guid("0ed38564-3050-4a21-af48-d17cd6cd4c60"), "Boris", "~/img/applicants/b.a.jpg", "Avramov", 1, 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "Id",
                keyValue: new Guid("4e2a1953-bab0-4614-9279-f89c50448ed8"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("9ac7482a-10ce-4d60-9d3b-4ccf2724887b"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "JobOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 2, 13, 33, 41, 479, DateTimeKind.Utc).AddTicks(6174),
                comment: "This is publish date of job offer",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 49, 19, 429, DateTimeKind.Utc).AddTicks(5256),
                oldComment: "This is publish date of job offer");
        }
    }
}
