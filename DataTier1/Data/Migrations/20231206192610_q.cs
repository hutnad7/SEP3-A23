using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class q : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    AuthorId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_AuthorId",
                        column: x => x.AuthorId,
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
                    { new Guid("2280de98-a867-43ce-8b87-25049fd45e9c"), new DateTime(2023, 12, 6, 20, 26, 10, 702, DateTimeKind.Local).AddTicks(3353), "enterteiner@gmail.com", "Enter", "Teiner", "-2064360427", 2, "enterteiner" },
                    { new Guid("275ef8cd-0d4f-486c-a1b9-5b6e5f01fcb8"), new DateTime(2023, 12, 6, 20, 26, 10, 702, DateTimeKind.Local).AddTicks(3289), "normaluser@gmail.com", "User", "Normal", "-1420581839", 0, "normal_user" },
                    { new Guid("8ca05d39-7ab2-47d7-9be0-4690e38252fc"), new DateTime(2023, 12, 6, 20, 26, 10, 702, DateTimeKind.Local).AddTicks(3196), "coffeowner@gmail.com", "Coffe", "Owner", "-333322552", 1, "CoffeOwnerTest" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2280de98-a867-43ce-8b87-25049fd45e9c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("275ef8cd-0d4f-486c-a1b9-5b6e5f01fcb8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ca05d39-7ab2-47d7-9be0-4690e38252fc"));

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
    }
}
