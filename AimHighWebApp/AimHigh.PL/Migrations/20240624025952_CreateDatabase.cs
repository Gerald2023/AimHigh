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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("4921fd33-ff04-415f-8c54-c97c68c12934"), "Professional" },
                    { new Guid("e32a54a9-99b0-4e73-8c2e-e5ed8756cc6e"), "Personal" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("4b609d1a-cbfb-4258-ab2b-2093bd334e03"), "Gerald@sample.com", "Gerald", "Vallejos", "pYfdnNb8sO0FgS4H0MRSwLGOIME=" },
                    { new Guid("85ffefff-0a71-4556-9516-e87fa9611073"), "smarin@sample.com", "Steve", "Marin", "pYfdnNb8sO0FgS4H0MRSwLGOIME=" }
                });

            migrationBuilder.InsertData(
                table: "tblGoal",
                columns: new[] { "Id", "Date", "Description", "ImagePath", "Progress", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("0273652f-5be7-461f-aa5e-22333555bf8b"), new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete online courses and build projects to learn ASP.NET Core.", "learn_aspnet_core.jpg", 0.0, "Learn ASP.NET Core", new Guid("85ffefff-0a71-4556-9516-e87fa9611073") },
                    { new Guid("1c5a301a-d295-4af9-8fb5-b5465cf8a218"), new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Read a variety of books across different genres.", "read_books.jpg", 0.0, "Read 20 Books", new Guid("4b609d1a-cbfb-4258-ab2b-2093bd334e03") }
                });

            migrationBuilder.InsertData(
                table: "tblMilestone",
                columns: new[] { "Id", "Date", "Description", "GoalId", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("76387678-6ada-46ad-a293-7b1149d549ce"), new DateTime(2024, 8, 22, 21, 59, 52, 84, DateTimeKind.Local).AddTicks(2997), "Finish the second online course.", new Guid("1c5a301a-d295-4af9-8fb5-b5465cf8a218"), "Pending", "Complete Course 2" },
                    { new Guid("b9acfb3f-962d-4138-8e38-7421e2138f0a"), new DateTime(2024, 7, 23, 21, 59, 52, 84, DateTimeKind.Local).AddTicks(2932), "Finish the first online course.", new Guid("0273652f-5be7-461f-aa5e-22333555bf8b"), "Pending", "Complete Course 1" }
                });

            migrationBuilder.InsertData(
                table: "tblTask",
                columns: new[] { "Id", "Date", "Description", "MilestoneId", "TagId", "Title", "UserId", "tblTagId" },
                values: new object[,]
                {
                    { new Guid("15a3f03d-4cdf-4b9c-add0-11c62cbfbf7d"), new DateTime(2024, 7, 7, 21, 59, 52, 85, DateTimeKind.Local).AddTicks(1899), "Write a review of the latest book read.", new Guid("76387678-6ada-46ad-a293-7b1149d549ce"), new Guid("4921fd33-ff04-415f-8c54-c97c68c12934"), "Write Book Review", new Guid("4b609d1a-cbfb-4258-ab2b-2093bd334e03"), null },
                    { new Guid("deace66a-6630-41c8-b469-27d4890f6bb7"), new DateTime(2024, 6, 30, 21, 59, 52, 85, DateTimeKind.Local).AddTicks(1862), "Read and complete exercises in Chapter 1 of the textbook.", new Guid("b9acfb3f-962d-4138-8e38-7421e2138f0a"), new Guid("e32a54a9-99b0-4e73-8c2e-e5ed8756cc6e"), "Complete Chapter 1", new Guid("85ffefff-0a71-4556-9516-e87fa9611073"), null }
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
