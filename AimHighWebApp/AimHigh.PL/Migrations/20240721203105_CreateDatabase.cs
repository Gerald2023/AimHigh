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
                    { new Guid("0be5e36f-4361-4655-95cf-19a7f1283daf"), "Professional" },
                    { new Guid("dee65825-5657-498e-b2fd-41bd0650b811"), "Personal" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("914d5bdd-1c4c-4d74-b78e-9c26e06ff2e9"), "Gerald@sample.com", "Gerald", "Vallejos", "pYfdnNb8sO0FgS4H0MRSwLGOIME=" },
                    { new Guid("ba7c2575-1ff4-4d91-a9db-40c4e37eac96"), "smarin@sample.com", "Steve", "Marin", "pYfdnNb8sO0FgS4H0MRSwLGOIME=" }
                });

            migrationBuilder.InsertData(
                table: "tblGoal",
                columns: new[] { "Id", "Date", "Description", "ImagePath", "Progress", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("6e28d0c4-d028-478d-b45a-6f032ae1ac64"), new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete online courses and build projects to learn ASP.NET Core.", "learn_aspnet_core.jpg", 0.0, "Learn ASP.NET Core", new Guid("ba7c2575-1ff4-4d91-a9db-40c4e37eac96") },
                    { new Guid("ee7a87ad-d2dc-427b-84f1-02b3e12d25b4"), new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Read a variety of books across different genres.", "read_books.jpg", 0.0, "Read 20 Books", new Guid("914d5bdd-1c4c-4d74-b78e-9c26e06ff2e9") }
                });

            migrationBuilder.InsertData(
                table: "tblMilestone",
                columns: new[] { "Id", "Date", "Description", "GoalId", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("2b1fd0dd-c5a3-4dff-af65-b18f867ae074"), new DateTime(2024, 8, 20, 15, 31, 4, 531, DateTimeKind.Local).AddTicks(2435), "Finish the first online course.", new Guid("6e28d0c4-d028-478d-b45a-6f032ae1ac64"), "Pending", "Complete Course 1" },
                    { new Guid("cfe1c5c9-8fb7-45e1-b697-c22e8cdb26b0"), new DateTime(2024, 9, 19, 15, 31, 4, 531, DateTimeKind.Local).AddTicks(2497), "Finish the second online course.", new Guid("ee7a87ad-d2dc-427b-84f1-02b3e12d25b4"), "Pending", "Complete Course 2" }
                });

            migrationBuilder.InsertData(
                table: "tblTask",
                columns: new[] { "Id", "Date", "Description", "MilestoneId", "TagId", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("59e25a3a-157d-40a6-bed5-8149176337dd"), new DateTime(2024, 8, 4, 15, 31, 4, 531, DateTimeKind.Local).AddTicks(6034), "Write a review of the latest book read.", new Guid("cfe1c5c9-8fb7-45e1-b697-c22e8cdb26b0"), new Guid("0be5e36f-4361-4655-95cf-19a7f1283daf"), "Write Book Review", new Guid("914d5bdd-1c4c-4d74-b78e-9c26e06ff2e9") },
                    { new Guid("8052fd9c-b3e4-4d04-9ef9-6621eaba5574"), new DateTime(2024, 7, 28, 15, 31, 4, 531, DateTimeKind.Local).AddTicks(5997), "Read and complete exercises in Chapter 1 of the textbook.", new Guid("2b1fd0dd-c5a3-4dff-af65-b18f867ae074"), new Guid("dee65825-5657-498e-b2fd-41bd0650b811"), "Complete Chapter 1", new Guid("ba7c2575-1ff4-4d91-a9db-40c4e37eac96") }
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
