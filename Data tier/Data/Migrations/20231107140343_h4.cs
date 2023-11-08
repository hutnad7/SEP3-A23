using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class h4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Firstname = table.Column<string>(type: "longtext", nullable: false),
                    Lastname = table.Column<string>(type: "longtext", nullable: false),
                    Username = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CafeOwnerId = table.Column<Guid>(type: "char(36)", nullable: false),
                    EnterteinerId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Text = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Users_CafeOwnerId",
                        column: x => x.CafeOwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Users_EnterteinerId",
                        column: x => x.EnterteinerId,
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
                    { new Guid("35710f3a-9c50-4342-9177-80cb31070e03"), new DateTime(2023, 11, 7, 16, 3, 43, 458, DateTimeKind.Local).AddTicks(9490), "enterteiner@gmail.com", "Enter", "Teiner", "2106867507", 2, "enterteiner" },
                    { new Guid("c3d34fb5-6d48-435e-afeb-ca6c31b33c70"), new DateTime(2023, 11, 7, 16, 3, 43, 458, DateTimeKind.Local).AddTicks(9367), "coffeowner@gmail.com", "Coffe", "Owner", "-1319681628", 1, "CoffeOwnerTest" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CafeOwnerId",
                table: "Events",
                column: "CafeOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EnterteinerId",
                table: "Events",
                column: "EnterteinerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
