using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class h1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35710f3a-9c50-4342-9177-80cb31070e03"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c3d34fb5-6d48-435e-afeb-ca6c31b33c70"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Email", "Firstname", "Lastname", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("1270a734-8eb9-437c-92a6-bfa1a78151d9"), new DateTime(2023, 11, 7, 16, 6, 20, 346, DateTimeKind.Local).AddTicks(9000), "enterteiner@gmail.com", "Enter", "Teiner", "1920443052", 2, "enterteiner" },
                    { new Guid("e8f48659-94a3-4bb6-90e3-a086bfbce13a"), new DateTime(2023, 11, 7, 16, 6, 20, 346, DateTimeKind.Local).AddTicks(8902), "coffeowner@gmail.com", "Coffe", "Owner", "2046887701", 1, "CoffeOwnerTest" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("35710f3a-9c50-4342-9177-80cb31070e03"), new DateTime(2023, 11, 7, 16, 3, 43, 458, DateTimeKind.Local).AddTicks(9490), "enterteiner@gmail.com", "Enter", "Teiner", "2106867507", 2, "enterteiner" },
                    { new Guid("c3d34fb5-6d48-435e-afeb-ca6c31b33c70"), new DateTime(2023, 11, 7, 16, 3, 43, 458, DateTimeKind.Local).AddTicks(9367), "coffeowner@gmail.com", "Coffe", "Owner", "-1319681628", 1, "CoffeOwnerTest" }
                });
        }
    }
}
