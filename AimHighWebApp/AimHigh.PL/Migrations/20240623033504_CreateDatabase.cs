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
                    ImagePath = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
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
                        principalColumn: "Id");
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
                        principalColumn: "Id");
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
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    tblTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTask_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblTask_tblMilestone",
                        column: x => x.MilestoneId,
                        principalTable: "tblMilestone",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblTask_tblTag",
                        column: x => x.TagId,
                        principalTable: "tblTag",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblTask_tblTag_tblTagId",
                        column: x => x.tblTagId,
                        principalTable: "tblTag",
                        principalColumn: "Id");
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
                    { new Guid("119ce5fc-330d-4786-9381-3a2fd187f771"), "Personal" },
                    { new Guid("30f8d13f-ec01-47b0-9fc0-30525b946f5a"), "Professional" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("122e48df-0422-4750-8a54-d06210f98bc2"), "Gerald@sample.com", "Gerald", "Vallejos", "pYfdnNb8sO0FgS4H0MRSwLGOIME=" },
                    { new Guid("7a7aafd9-032f-4951-90bb-341f1e3ce95f"), "smarin@sample.com", "Steve", "Marin", "pYfdnNb8sO0FgS4H0MRSwLGOIME=" }
                });

            migrationBuilder.InsertData(
                table: "tblGoal",
                columns: new[] { "Id", "Date", "Description", "ImagePath", "Progress", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("bdb123f3-d925-4ae2-a6dd-6c92495c5bdd"), new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete online courses and build projects to learn ASP.NET Core.", "learn_aspnet_core.jpg", 0.0, "Learn ASP.NET Core", new Guid("7a7aafd9-032f-4951-90bb-341f1e3ce95f") },
                    { new Guid("c007abd2-b17b-44e4-bae2-e6f0b391680e"), new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Read a variety of books across different genres.", "read_books.jpg", 0.0, "Read 20 Books", new Guid("122e48df-0422-4750-8a54-d06210f98bc2") }
                });

            migrationBuilder.InsertData(
                table: "tblMilestone",
                columns: new[] { "Id", "Date", "Description", "GoalId", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("b9e6bece-0899-4c89-b92c-2b7c481aa5a6"), new DateTime(2024, 7, 22, 22, 35, 4, 100, DateTimeKind.Local).AddTicks(884), "Finish the first online course.", new Guid("bdb123f3-d925-4ae2-a6dd-6c92495c5bdd"), "Pending", "Complete Course 1" },
                    { new Guid("dcbd89e0-0f8c-41fe-b34d-c83c6db06ab9"), new DateTime(2024, 8, 21, 22, 35, 4, 100, DateTimeKind.Local).AddTicks(949), "Finish the second online course.", new Guid("c007abd2-b17b-44e4-bae2-e6f0b391680e"), "Pending", "Complete Course 2" }
                });

            migrationBuilder.InsertData(
                table: "tblTask",
                columns: new[] { "Id", "Date", "Description", "MilestoneId", "TagId", "Title", "UserId", "tblTagId" },
                values: new object[,]
                {
                    { new Guid("4a351097-1115-4dd3-b8a2-5aaadd545e76"), new DateTime(2024, 6, 29, 22, 35, 4, 101, DateTimeKind.Local).AddTicks(468), "Read and complete exercises in Chapter 1 of the textbook.", new Guid("b9e6bece-0899-4c89-b92c-2b7c481aa5a6"), new Guid("119ce5fc-330d-4786-9381-3a2fd187f771"), "Complete Chapter 1", new Guid("7a7aafd9-032f-4951-90bb-341f1e3ce95f"), null },
                    { new Guid("80c67f2f-4c23-4d95-9041-06835b1fb699"), new DateTime(2024, 7, 6, 22, 35, 4, 101, DateTimeKind.Local).AddTicks(510), "Write a review of the latest book read.", new Guid("dcbd89e0-0f8c-41fe-b34d-c83c6db06ab9"), new Guid("30f8d13f-ec01-47b0-9fc0-30525b946f5a"), "Write Book Review", new Guid("122e48df-0422-4750-8a54-d06210f98bc2"), null }
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
                name: "IX_tblTask_tblTagId",
                table: "tblTask",
                column: "tblTagId");

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
