using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AimHigh.PL.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblTag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTag_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(28)", unicode: false, maxLength: 28, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblGoal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Progress = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGoal_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblGoal_tblUser",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMilestone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMilestone_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblMilestone_tblGoal",
                        column: x => x.GoalId,
                        principalTable: "tblGoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MilestoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTask_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblTask_tblMilestone",
                        column: x => x.MilestoneId,
                        principalTable: "tblMilestone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblTask_tblTag_TagId",
                        column: x => x.TagId,
                        principalTable: "tblTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblTask_tblUser",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "tblTag",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("3d9a3a04-ca07-486b-8817-58871807631d"), "Professional" },
                    { new Guid("b16b574e-d2c2-4d48-b35a-66442dfa4e39"), "Personal" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("dd730944-9f73-4ca4-b89d-01f88492aa28"), "smarin@sample.com", "Steve", "Marin", "pYfdnNb8sO0FgS4H0MRSwLGOIME=" },
                    { new Guid("fc28e6a0-dc19-4c32-84d6-f58cc1fca7e2"), "Gerald@sample.com", "Gerald", "Vallejos", "pYfdnNb8sO0FgS4H0MRSwLGOIME=" }
                });

            migrationBuilder.InsertData(
                table: "tblGoal",
                columns: new[] { "Id", "Date", "Description", "ImagePath", "Progress", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("1e373b84-2a2f-4ff2-93a8-5c32ba4396ec"), new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete online courses and build projects to learn ASP.NET Core.", "learn_aspnet_core.jpg", 0.0, "Learn ASP.NET Core", new Guid("dd730944-9f73-4ca4-b89d-01f88492aa28") },
                    { new Guid("a9fd987a-e1a0-4d87-99a7-1174bce1f8f4"), new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Read a variety of books across different genres.", "read_books.jpg", 0.0, "Read 20 Books", new Guid("fc28e6a0-dc19-4c32-84d6-f58cc1fca7e2") }
                });

            migrationBuilder.InsertData(
                table: "tblMilestone",
                columns: new[] { "Id", "Date", "Description", "GoalId", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("62e8c914-2473-46f6-beb1-a31a87de96e9"), new DateTime(2024, 8, 4, 15, 25, 21, 88, DateTimeKind.Local).AddTicks(992), "Finish the first online course.", new Guid("1e373b84-2a2f-4ff2-93a8-5c32ba4396ec"), "Pending", "Complete Course 1" },
                    { new Guid("9542f6b8-2a62-4a69-bdd1-52e592661806"), new DateTime(2024, 9, 3, 15, 25, 21, 88, DateTimeKind.Local).AddTicks(1053), "Finish the second online course.", new Guid("a9fd987a-e1a0-4d87-99a7-1174bce1f8f4"), "Pending", "Complete Course 2" }
                });

            migrationBuilder.InsertData(
                table: "tblTask",
                columns: new[] { "Id", "Date", "Description", "MilestoneId", "TagId", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("32e7f291-9837-4ad5-ac28-dc932f1dd363"), new DateTime(2024, 7, 12, 15, 25, 21, 88, DateTimeKind.Local).AddTicks(4324), "Read and complete exercises in Chapter 1 of the textbook.", new Guid("62e8c914-2473-46f6-beb1-a31a87de96e9"), new Guid("b16b574e-d2c2-4d48-b35a-66442dfa4e39"), "Complete Chapter 1", new Guid("dd730944-9f73-4ca4-b89d-01f88492aa28") },
                    { new Guid("91581e18-180d-45c7-814b-6e4c6dd0109a"), new DateTime(2024, 7, 19, 15, 25, 21, 88, DateTimeKind.Local).AddTicks(4367), "Write a review of the latest book read.", new Guid("9542f6b8-2a62-4a69-bdd1-52e592661806"), new Guid("3d9a3a04-ca07-486b-8817-58871807631d"), "Write Book Review", new Guid("fc28e6a0-dc19-4c32-84d6-f58cc1fca7e2") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblGoal_UserId",
                table: "tblGoal",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMilestone_GoalId",
                table: "tblMilestone",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTask_MilestoneId",
                table: "tblTask",
                column: "MilestoneId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTask_TagId",
                table: "tblTask",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTask_UserId",
                table: "tblTask",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblTask");

            migrationBuilder.DropTable(
                name: "tblMilestone");

            migrationBuilder.DropTable(
                name: "tblTag");

            migrationBuilder.DropTable(
                name: "tblGoal");

            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
