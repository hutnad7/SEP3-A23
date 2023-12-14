using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
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
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Username = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    CreationDate = table.Column<string>(type: "longtext", nullable: false),
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
                    CreationDate = table.Column<string>(type: "longtext", nullable: false),
                    StartDate = table.Column<string>(type: "longtext", nullable: false),
                    EndDate = table.Column<string>(type: "longtext", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Text = table.Column<string>(type: "longtext", nullable: false),
                    AvailablePlaces = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    EventId = table.Column<Guid>(type: "char(36)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    AuthorId = table.Column<Guid>(type: "char(36)", nullable: false),
                    EventId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreationDate = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
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
                columns: new[] { "Id", "CreationDate", "Description", "Email", "FirstName", "LastName", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("1fd99f02-ddd9-416f-afa5-8c8006dca890"), "13/12/2023 21.38.33", "", "normaluser@gmail.com", "User", "Normal", "EFkBVq44Z8u3DLJIDFCsNA==:d1qfGLlmWGU5jlGw4c1FyCsg4t042AaMFfC0LjIcZAU=", 0, "normal_user" },
                    { new Guid("910a3cc5-8f4d-4008-a26f-aa4b76668e3d"), "13/12/2023 21.38.33", "Enterteiner", "enterteiner@gmail.com", "Enter", "Teiner", "Z7b3ZGW6cxsbHXvSg5Ujcw==:xlnbrWcFeqOQPvhccjVF2ls+uKq+pXgaX7WGT3fGapY=", 2, "enterteiner" },
                    { new Guid("b8b0d1a3-77a6-4b01-afe9-d787e0be11e3"), "13/12/2023 21.38.33", "Cafe Owner", "coffeowner@gmail.com", "Coffe", "Owner", "5Ej6fpmoaH0R5wNu2dGmUQ==:+WKdZGdAOMNpOc94QzsDpJyo0cSIDIlcuNJVMLwhPuM=", 1, "CoffeOwnerTest" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EventId",
                table: "Bookings",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CafeOwnerId",
                table: "Events",
                column: "CafeOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EnterteinerId",
                table: "Events",
                column: "EnterteinerId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_EventId",
                table: "Posts",
                column: "EventId");

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
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
