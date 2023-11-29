using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addedState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "state",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Email", "Firstname", "Lastname", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("70c38fa9-62ad-438d-a245-3d44bda8675e"), new DateTime(2023, 11, 28, 13, 4, 43, 74, DateTimeKind.Local).AddTicks(6689), "coffeowner@gmail.com", "Coffe", "Owner", "616136064", 1, "CoffeOwnerTest" },
                    { new Guid("c60f40aa-9028-4036-9c09-192dceb95f73"), new DateTime(2023, 11, 28, 13, 4, 43, 74, DateTimeKind.Local).AddTicks(6790), "enterteiner@gmail.com", "Enter", "Teiner", "33361348", 2, "enterteiner" },
                    { new Guid("ec219f26-9475-4192-922b-484ce92ad381"), new DateTime(2023, 11, 28, 13, 4, 43, 74, DateTimeKind.Local).AddTicks(6771), "normaluser@gmail.com", "User", "Normal", "824479591", 0, "normal_user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("70c38fa9-62ad-438d-a245-3d44bda8675e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c60f40aa-9028-4036-9c09-192dceb95f73"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ec219f26-9475-4192-922b-484ce92ad381"));

            migrationBuilder.DropColumn(
                name: "state",
                table: "Events");

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
    }
}
