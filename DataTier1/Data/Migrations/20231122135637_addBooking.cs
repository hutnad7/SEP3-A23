using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0d8d4874-3b70-445c-98ef-eb9c2306ba55"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2ef5bf7b-11a9-41cc-aed0-fe37e3b46e62"));

            migrationBuilder.AddColumn<int>(
                name: "AvailablePlaces",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    EventId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Email", "Firstname", "Lastname", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("54a606f1-c5a9-475d-82e4-e9534c0f93f6"), new DateTime(2023, 11, 22, 15, 56, 37, 97, DateTimeKind.Local).AddTicks(9319), "enterteiner@gmail.com", "Enter", "Teiner", "1917760719", 2, "enterteiner" },
                    { new Guid("8a34711c-00a2-49f3-800e-6cba7fdaf772"), new DateTime(2023, 11, 22, 15, 56, 37, 97, DateTimeKind.Local).AddTicks(9157), "coffeowner@gmail.com", "Coffe", "Owner", "-1847320417", 1, "CoffeOwnerTest" },
                    { new Guid("d3d99d3d-bd21-4ed2-87d3-eabc8be202ec"), new DateTime(2023, 11, 22, 15, 56, 37, 97, DateTimeKind.Local).AddTicks(9288), "normaluser@gmail.com", "User", "Normal", "1682876097", 0, "normal_user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EventId",
                table: "Bookings",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

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

            migrationBuilder.DropColumn(
                name: "AvailablePlaces",
                table: "Events");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Email", "Firstname", "Lastname", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("0d8d4874-3b70-445c-98ef-eb9c2306ba55"), new DateTime(2023, 11, 7, 16, 8, 17, 932, DateTimeKind.Local).AddTicks(2190), "coffeowner@gmail.com", "Coffe", "Owner", "-1417871599", 1, "CoffeOwnerTest" },
                    { new Guid("2ef5bf7b-11a9-41cc-aed0-fe37e3b46e62"), new DateTime(2023, 11, 7, 16, 8, 17, 932, DateTimeKind.Local).AddTicks(2323), "enterteiner@gmail.com", "Enter", "Teiner", "764849110", 2, "enterteiner" }
                });
        }
    }
}
