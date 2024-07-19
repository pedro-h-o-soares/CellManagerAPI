using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CellManagerAPI.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "266ba278-0e3a-4e0f-84a0-25df32f42d34", null, "Supervisor", "SUPERVISOR" },
                    { "49443600-f652-4665-af6e-5c9c0405f696", null, "Leader", "LEADER" },
                    { "d17e5a08-672d-490c-8c83-05c28e1c053d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "582df6a9-d3a2-43ea-90c5-207ec806fab2", 0, "d3a847bb-fc04-4cdb-826f-314c80bff208", null, false, false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEAjzE429JtW70RTKA0vECjZ4D8oNzMZgKCemXzbf0u8qNsghBQHzp9yr5ZnaDPBF1Q==", null, false, "fc72ef7f-3252-498c-8785-48bfb878237d", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d17e5a08-672d-490c-8c83-05c28e1c053d", "582df6a9-d3a2-43ea-90c5-207ec806fab2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "266ba278-0e3a-4e0f-84a0-25df32f42d34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49443600-f652-4665-af6e-5c9c0405f696");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d17e5a08-672d-490c-8c83-05c28e1c053d", "582df6a9-d3a2-43ea-90c5-207ec806fab2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d17e5a08-672d-490c-8c83-05c28e1c053d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "582df6a9-d3a2-43ea-90c5-207ec806fab2");
        }
    }
}
