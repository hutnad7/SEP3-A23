using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class o : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Users",
                type: "longtext",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    AuthorId = table.Column<Guid>(type: "char(36)", nullable: false),
                    EventId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "CreationDate", "Description", "Email", "Firstname", "Lastname", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("2a5cbc51-a2fa-42e1-8357-c13395a79a74"), new DateTime(2023, 12, 5, 17, 0, 35, 827, DateTimeKind.Local).AddTicks(3032), "", "normaluser@gmail.com", "User", "Normal", "1013436685", 0, "normal_user" },
                    { new Guid("6d39fd49-55c3-4c30-a7b8-2079f87455ba"), new DateTime(2023, 12, 5, 17, 0, 35, 827, DateTimeKind.Local).AddTicks(2904), "Cafe Owner", "coffeowner@gmail.com", "Coffe", "Owner", "-660948321", 1, "CoffeOwnerTest" },
                    { new Guid("c5d23c9a-d1cc-4699-83e8-68d23ae376de"), new DateTime(2023, 12, 5, 17, 0, 35, 827, DateTimeKind.Local).AddTicks(3048), "Enterteiner", "enterteiner@gmail.com", "Enter", "Teiner", "-1115407542", 2, "enterteiner" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_EventId",
                table: "Posts",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Users");

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
