using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class _27nov : Migration
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Email", "Firstname", "Lastname", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("75d0d2c8-d933-4c13-96fd-4cda008e3327"), new DateTime(2023, 11, 27, 14, 37, 43, 425, DateTimeKind.Local).AddTicks(8970), "coffeowner@gmail.com", "Coffe", "Owner", "-1472469731", 1, "CoffeOwnerTest" },
                    { new Guid("a4f3e04a-8ee0-436e-b628-8873cd77508d"), new DateTime(2023, 11, 27, 14, 37, 43, 425, DateTimeKind.Local).AddTicks(9058), "normaluser@gmail.com", "User", "Normal", "1520653645", 0, "normal_user" },
                    { new Guid("f1ca2ca9-e322-4bb3-91ac-db0edfb3d324"), new DateTime(2023, 11, 27, 14, 37, 43, 425, DateTimeKind.Local).AddTicks(9082), "enterteiner@gmail.com", "Enter", "Teiner", "-822210838", 2, "enterteiner" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("75d0d2c8-d933-4c13-96fd-4cda008e3327"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a4f3e04a-8ee0-436e-b628-8873cd77508d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f1ca2ca9-e322-4bb3-91ac-db0edfb3d324"));

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
