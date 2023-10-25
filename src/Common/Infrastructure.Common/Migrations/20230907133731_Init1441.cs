using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Common.Migrations
{
    /// <inheritdoc />
    public partial class Init1441 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("13ad6213-7ed2-4fc0-9db6-900d462f2229"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("91dadb3c-59b3-4c65-a8cb-9364b3ce43fa"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("612e1f68-a396-4a87-ab2f-607da8bfffd2"), "Admin" },
                    { new Guid("f922b6ed-206d-4ed5-8c46-2d226bec3e77"), "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("612e1f68-a396-4a87-ab2f-607da8bfffd2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f922b6ed-206d-4ed5-8c46-2d226bec3e77"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("13ad6213-7ed2-4fc0-9db6-900d462f2229"), "User" },
                    { new Guid("91dadb3c-59b3-4c65-a8cb-9364b3ce43fa"), "Admin" }
                });
        }
    }
}
