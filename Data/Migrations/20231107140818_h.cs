using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class h : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1270a734-8eb9-437c-92a6-bfa1a78151d9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e8f48659-94a3-4bb6-90e3-a086bfbce13a"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Email", "Firstname", "Lastname", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("0d8d4874-3b70-445c-98ef-eb9c2306ba55"), new DateTime(2023, 11, 7, 16, 8, 17, 932, DateTimeKind.Local).AddTicks(2190), "coffeowner@gmail.com", "Coffe", "Owner", "-1417871599", 1, "CoffeOwnerTest" },
                    { new Guid("2ef5bf7b-11a9-41cc-aed0-fe37e3b46e62"), new DateTime(2023, 11, 7, 16, 8, 17, 932, DateTimeKind.Local).AddTicks(2323), "enterteiner@gmail.com", "Enter", "Teiner", "764849110", 2, "enterteiner" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0d8d4874-3b70-445c-98ef-eb9c2306ba55"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2ef5bf7b-11a9-41cc-aed0-fe37e3b46e62"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Email", "Firstname", "Lastname", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("1270a734-8eb9-437c-92a6-bfa1a78151d9"), new DateTime(2023, 11, 7, 16, 6, 20, 346, DateTimeKind.Local).AddTicks(9000), "enterteiner@gmail.com", "Enter", "Teiner", "1920443052", 2, "enterteiner" },
                    { new Guid("e8f48659-94a3-4bb6-90e3-a086bfbce13a"), new DateTime(2023, 11, 7, 16, 6, 20, 346, DateTimeKind.Local).AddTicks(8902), "coffeowner@gmail.com", "Coffe", "Owner", "2046887701", 1, "CoffeOwnerTest" }
                });
        }
    }
}
