using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Heisenberg.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "Description", "DueDate", "IsComplete", "LastModifiedBy", "LastModifiedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 1", new DateTime(2023, 5, 25, 13, 5, 2, 758, DateTimeKind.Utc).AddTicks(1960), false, null, null },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 2", new DateTime(2023, 5, 25, 13, 5, 2, 758, DateTimeKind.Utc).AddTicks(1963), false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "13", 0, "dbea3548-f8cc-4ff3-ad13-85a8211ff3d7", "IdentityUser", "your@email.com", true, false, null, "YOUREMAIL@EMAIL.COM", "YOURUSERNAME", "AQAAAAIAAYagAAAAEP7DD0VttoLvX/exgnM6QaCIGKB8GGR2TOTqpcWl0uMvh212DgVfSuoxEJ2UMhQolA==", null, false, "9336684e-6f3b-4222-ae6f-aee5d3670034", false, "YourUsername" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13");
        }
    }
}
