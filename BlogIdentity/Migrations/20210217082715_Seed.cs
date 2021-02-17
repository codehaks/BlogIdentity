using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogIdentity.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Name", "TimeCreated" },
                values: new object[,]
                {
                    { 1, "Codehaks", new DateTime(2021, 2, 17, 11, 57, 14, 968, DateTimeKind.Local).AddTicks(8080) },
                    { 2, "Devs", new DateTime(2021, 2, 12, 11, 57, 14, 973, DateTimeKind.Local).AddTicks(1) },
                    { 3, "Dotnet", new DateTime(2021, 2, 14, 11, 57, 14, 973, DateTimeKind.Local).AddTicks(162) },
                    { 4, "Aspcore", new DateTime(2021, 2, 15, 11, 57, 14, 973, DateTimeKind.Local).AddTicks(185) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
