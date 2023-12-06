using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class op : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2a5cbc51-a2fa-42e1-8357-c13395a79a74"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6d39fd49-55c3-4c30-a7b8-2079f87455ba"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c5d23c9a-d1cc-4699-83e8-68d23ae376de"));

            migrationBuilder.AlterColumn<string>(
                name: "CreationDate",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "CreationDate",
                table: "Posts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "Events",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "Events",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "CreationDate",
                table: "Events",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Description", "Email", "Firstname", "Lastname", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("85ca6e30-075d-438d-a239-48d2ce1076e7"), "05/12/2023 17:49:11", "Cafe Owner", "coffeowner@gmail.com", "Coffe", "Owner", "291333243", 1, "CoffeOwnerTest" },
                    { new Guid("b488d487-58cd-496d-8e51-6952ff771c97"), "05/12/2023 17:49:11", "Enterteiner", "enterteiner@gmail.com", "Enter", "Teiner", "-1091989785", 2, "enterteiner" },
                    { new Guid("eafa239b-dbfa-4866-b6b8-ac03cf287d22"), "05/12/2023 17:49:11", "", "normaluser@gmail.com", "User", "Normal", "996018477", 0, "normal_user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("85ca6e30-075d-438d-a239-48d2ce1076e7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b488d487-58cd-496d-8e51-6952ff771c97"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("eafa239b-dbfa-4866-b6b8-ac03cf287d22"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Posts",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Events",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Events",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Events",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Description", "Email", "Firstname", "Lastname", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("2a5cbc51-a2fa-42e1-8357-c13395a79a74"), new DateTime(2023, 12, 5, 17, 0, 35, 827, DateTimeKind.Local).AddTicks(3032), "", "normaluser@gmail.com", "User", "Normal", "1013436685", 0, "normal_user" },
                    { new Guid("6d39fd49-55c3-4c30-a7b8-2079f87455ba"), new DateTime(2023, 12, 5, 17, 0, 35, 827, DateTimeKind.Local).AddTicks(2904), "Cafe Owner", "coffeowner@gmail.com", "Coffe", "Owner", "-660948321", 1, "CoffeOwnerTest" },
                    { new Guid("c5d23c9a-d1cc-4699-83e8-68d23ae376de"), new DateTime(2023, 12, 5, 17, 0, 35, 827, DateTimeKind.Local).AddTicks(3048), "Enterteiner", "enterteiner@gmail.com", "Enter", "Teiner", "-1115407542", 2, "enterteiner" }
                });
        }
    }
}
