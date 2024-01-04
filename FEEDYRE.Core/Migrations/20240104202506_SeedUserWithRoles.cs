using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FEEDYRE.Core.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserWithRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("550c9fb1-ba46-44ac-bc43-0e32cb1b80ad"), "Admin" },
                    { new Guid("8da6bd0d-6e3f-4912-a97a-e0c814ef5528"), "Sensei" },
                    { new Guid("da526b84-4281-4b90-a853-ce6fcc26163e"), "Trainee" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[] { new Guid("b31966e3-1d47-420c-b62f-366a3d950991"), "admin", "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("995656e9-3c9e-480d-9847-dbe058aea3ff"), new Guid("550c9fb1-ba46-44ac-bc43-0e32cb1b80ad"), new Guid("b31966e3-1d47-420c-b62f-366a3d950991") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8da6bd0d-6e3f-4912-a97a-e0c814ef5528"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("da526b84-4281-4b90-a853-ce6fcc26163e"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("995656e9-3c9e-480d-9847-dbe058aea3ff"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("550c9fb1-ba46-44ac-bc43-0e32cb1b80ad"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b31966e3-1d47-420c-b62f-366a3d950991"));
        }
    }
}
