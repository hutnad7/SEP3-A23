using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class nov : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("54a606f1-c5a9-475d-82e4-e9534c0f93f6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8a34711c-00a2-49f3-800e-6cba7fdaf772"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d3d99d3d-bd21-4ed2-87d3-eabc8be202ec"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Email", "Firstname", "Lastname", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("4a754225-8370-498e-803f-c467e0ce405a"), new DateTime(2023, 11, 27, 13, 45, 33, 580, DateTimeKind.Local).AddTicks(4366), "enterteiner@gmail.com", "Enter", "Teiner", "-2087047826", 2, "enterteiner" },
                    { new Guid("8ce4dccf-1828-4c08-99b4-a0f0d026af5c"), new DateTime(2023, 11, 27, 13, 45, 33, 580, DateTimeKind.Local).AddTicks(4271), "coffeowner@gmail.com", "Coffe", "Owner", "2040000821", 1, "CoffeOwnerTest" },
                    { new Guid("c87450ad-fcf3-479f-a4d6-10042cd78720"), new DateTime(2023, 11, 27, 13, 45, 33, 580, DateTimeKind.Local).AddTicks(4353), "normaluser@gmail.com", "User", "Normal", "2034148697", 0, "normal_user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4a754225-8370-498e-803f-c467e0ce405a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ce4dccf-1828-4c08-99b4-a0f0d026af5c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c87450ad-fcf3-479f-a4d6-10042cd78720"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Email", "Firstname", "Lastname", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("54a606f1-c5a9-475d-82e4-e9534c0f93f6"), new DateTime(2023, 11, 22, 15, 56, 37, 97, DateTimeKind.Local).AddTicks(9319), "enterteiner@gmail.com", "Enter", "Teiner", "1917760719", 2, "enterteiner" },
                    { new Guid("8a34711c-00a2-49f3-800e-6cba7fdaf772"), new DateTime(2023, 11, 22, 15, 56, 37, 97, DateTimeKind.Local).AddTicks(9157), "coffeowner@gmail.com", "Coffe", "Owner", "-1847320417", 1, "CoffeOwnerTest" },
                    { new Guid("d3d99d3d-bd21-4ed2-87d3-eabc8be202ec"), new DateTime(2023, 11, 22, 15, 56, 37, 97, DateTimeKind.Local).AddTicks(9288), "normaluser@gmail.com", "User", "Normal", "1682876097", 0, "normal_user" }
                });
        }
    }
}
