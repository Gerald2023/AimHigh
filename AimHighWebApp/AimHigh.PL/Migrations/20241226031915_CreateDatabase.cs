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
                    { new Guid("80ba9cb8-d284-40ad-aa16-b5b3a67d3e92"), "Professional" },
                    { new Guid("aa97d7c9-4bbb-48fe-8b9d-21d57acfb0fe"), "Personal" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("76608aca-5cd2-401e-ab21-cc58f3bc7cee"), "Gerald@sample.com", "Gerald", "Vallejos", "pYfdnNb8sO0FgS4H0MRSwLGOIME=" },
                    { new Guid("e8c3d0b5-a360-4ecf-9905-29428bae0725"), "smarin@sample.com", "Steve", "Marin", "pYfdnNb8sO0FgS4H0MRSwLGOIME=" }
                });

            migrationBuilder.InsertData(
                table: "tblGoal",
                columns: new[] { "Id", "Date", "Description", "ImagePath", "Progress", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("15edf035-4cb1-4e36-a87b-2a4c50db4654"), new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete online courses and build projects to learn ASP.NET Core.", "learn_aspnet_core.jpg", 0.0, "Learn ASP.NET Core", new Guid("e8c3d0b5-a360-4ecf-9905-29428bae0725") },
                    { new Guid("5d84ef0e-eb08-48df-8ed3-51ad89c9bde8"), new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Read a variety of books across different genres.", "read_books.jpg", 0.0, "Read 20 Books", new Guid("76608aca-5cd2-401e-ab21-cc58f3bc7cee") }
                });

            migrationBuilder.InsertData(
                table: "tblMilestone",
                columns: new[] { "Id", "Date", "Description", "GoalId", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("4c2f8877-0eea-4f3d-bbbc-14172b54e180"), new DateTime(2025, 1, 24, 21, 19, 14, 630, DateTimeKind.Local).AddTicks(1249), "Finish the first online course.", new Guid("15edf035-4cb1-4e36-a87b-2a4c50db4654"), "Pending", "Complete Course 1" },
                    { new Guid("6857dc5f-2b78-4b76-9e3a-f6338d02ff21"), new DateTime(2025, 2, 23, 21, 19, 14, 630, DateTimeKind.Local).AddTicks(1311), "Finish the second online course.", new Guid("5d84ef0e-eb08-48df-8ed3-51ad89c9bde8"), "Pending", "Complete Course 2" }
                });

            migrationBuilder.InsertData(
                table: "tblTask",
                columns: new[] { "Id", "Date", "Description", "MilestoneId", "TagId", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("7ec93e90-6a96-4846-9be0-8cb67fa46885"), new DateTime(2025, 1, 8, 21, 19, 14, 630, DateTimeKind.Local).AddTicks(4928), "Write a review of the latest book read.", new Guid("6857dc5f-2b78-4b76-9e3a-f6338d02ff21"), new Guid("80ba9cb8-d284-40ad-aa16-b5b3a67d3e92"), "Write Book Review", new Guid("76608aca-5cd2-401e-ab21-cc58f3bc7cee") },
                    { new Guid("f522d07d-9073-4771-91ed-bd364112ab42"), new DateTime(2025, 1, 1, 21, 19, 14, 630, DateTimeKind.Local).AddTicks(4890), "Read and complete exercises in Chapter 1 of the textbook.", new Guid("4c2f8877-0eea-4f3d-bbbc-14172b54e180"), new Guid("aa97d7c9-4bbb-48fe-8b9d-21d57acfb0fe"), "Complete Chapter 1", new Guid("e8c3d0b5-a360-4ecf-9905-29428bae0725") }
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
