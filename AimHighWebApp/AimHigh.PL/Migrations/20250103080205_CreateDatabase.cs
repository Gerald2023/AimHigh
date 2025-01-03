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
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProject_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProject_tblUser",
                        column: x => x.OwnerId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblBoard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBoard_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblBoard_tblProject",
                        column: x => x.ProjectId,
                        principalTable: "tblProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblGoal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Progress = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGoal_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblGoal_tblProject",
                        column: x => x.ProjectId,
                        principalTable: "tblProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblColumn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    WIPLimit = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblColumn_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblColumn_tblBoard",
                        column: x => x.BoardId,
                        principalTable: "tblBoard",
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
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMilestone_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblMilestone_tblGoal",
                        column: x => x.GoalId,
                        principalTable: "tblGoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColumnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MilestoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssigneeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTask_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblTask_tblColumn",
                        column: x => x.ColumnId,
                        principalTable: "tblColumn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblTask_tblMilestone",
                        column: x => x.MilestoneId,
                        principalTable: "tblMilestone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblTask_tblTag",
                        column: x => x.TagId,
                        principalTable: "tblTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_tblTask_tblUser",
                        column: x => x.AssigneeId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "tblTag",
                columns: new[] { "Id", "Color", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("27f382d2-4ab0-479e-a8cf-e473ef454c01"), "#C70039", new DateTime(2025, 1, 3, 8, 2, 4, 725, DateTimeKind.Utc).AddTicks(8364), null, "High Priority" },
                    { new Guid("f21663ae-7a28-4b4e-901a-dbe7b881e7ed"), "#FF5733", new DateTime(2025, 1, 3, 8, 2, 4, 725, DateTimeKind.Utc).AddTicks(8362), null, "Frontend" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { new Guid("90cce612-3658-4219-af21-ab5f41eedaed"), "john.doe@example.com", "John", "Doe", "Ov7tBO7KAvNiYFcbGd6wiYrfq889AoOqzcnK+4HgsOE=" });

            migrationBuilder.InsertData(
                table: "tblProject",
                columns: new[] { "Id", "CreatedAt", "Description", "ModifiedAt", "Name", "OwnerId" },
                values: new object[] { new Guid("57ff96d0-2815-40e1-b74d-c9a41ac539f4"), new DateTime(2025, 1, 3, 8, 2, 4, 725, DateTimeKind.Utc).AddTicks(8250), "Complete overhaul of company website", null, "Website Redesign", new Guid("90cce612-3658-4219-af21-ab5f41eedaed") });

            migrationBuilder.InsertData(
                table: "tblBoard",
                columns: new[] { "Id", "CreatedAt", "Description", "ModifiedAt", "Name", "ProjectId" },
                values: new object[] { new Guid("e48adb57-e598-4eb8-b42f-5a82de8a1f55"), new DateTime(2025, 1, 3, 8, 2, 4, 725, DateTimeKind.Utc).AddTicks(8276), "Track development progress", null, "Development Tasks", new Guid("57ff96d0-2815-40e1-b74d-c9a41ac539f4") });

            migrationBuilder.InsertData(
                table: "tblGoal",
                columns: new[] { "Id", "CreatedAt", "Description", "DueDate", "ModifiedAt", "Progress", "ProjectId", "Title" },
                values: new object[] { new Guid("0c916a43-bdf2-46df-b26b-fafbd5da960a"), new DateTime(2025, 1, 3, 8, 2, 4, 725, DateTimeKind.Utc).AddTicks(8327), "Complete and launch the new company website", new DateTime(2025, 4, 3, 8, 2, 4, 725, DateTimeKind.Utc).AddTicks(8321), null, 0.0, new Guid("57ff96d0-2815-40e1-b74d-c9a41ac539f4"), "Launch New Website" });

            migrationBuilder.InsertData(
                table: "tblColumn",
                columns: new[] { "Id", "BoardId", "CreatedAt", "ModifiedAt", "Name", "Order", "WIPLimit" },
                values: new object[,]
                {
                    { new Guid("0a6c8c66-346f-4028-8779-4ba7ce03e960"), new Guid("e48adb57-e598-4eb8-b42f-5a82de8a1f55"), new DateTime(2025, 1, 3, 8, 2, 4, 725, DateTimeKind.Utc).AddTicks(8300), null, "Done", 3, null },
                    { new Guid("37ca78cb-fa3a-45e6-b9ac-f16ca457c709"), new Guid("e48adb57-e598-4eb8-b42f-5a82de8a1f55"), new DateTime(2025, 1, 3, 8, 2, 4, 725, DateTimeKind.Utc).AddTicks(8299), null, "In Progress", 2, 3 },
                    { new Guid("708404f5-c420-4abe-baa6-b8e7aca4e2d5"), new Guid("e48adb57-e598-4eb8-b42f-5a82de8a1f55"), new DateTime(2025, 1, 3, 8, 2, 4, 725, DateTimeKind.Utc).AddTicks(8296), null, "To Do", 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "tblMilestone",
                columns: new[] { "Id", "CreatedAt", "Description", "DueDate", "GoalId", "ModifiedAt", "Status", "Title" },
                values: new object[] { new Guid("c1dcd39f-4bec-4067-a7ec-1ecd0ea5205e"), new DateTime(2025, 1, 3, 8, 2, 4, 725, DateTimeKind.Utc).AddTicks(8345), "Complete all frontend components", new DateTime(2025, 2, 3, 8, 2, 4, 725, DateTimeKind.Utc).AddTicks(8344), new Guid("0c916a43-bdf2-46df-b26b-fafbd5da960a"), null, "NotStarted", "Frontend Development" });

            migrationBuilder.InsertData(
                table: "tblTask",
                columns: new[] { "Id", "AssigneeId", "ColumnId", "CreatedAt", "Description", "DueDate", "MilestoneId", "ModifiedAt", "Order", "Priority", "TagId", "Title" },
                values: new object[,]
                {
                    { new Guid("886a9190-dd9d-4aad-be36-fd7452c3b693"), new Guid("90cce612-3658-4219-af21-ab5f41eedaed"), new Guid("708404f5-c420-4abe-baa6-b8e7aca4e2d5"), new DateTime(2025, 1, 3, 8, 2, 4, 725, DateTimeKind.Utc).AddTicks(8395), "Implement responsive navigation menu", new DateTime(2025, 1, 8, 8, 2, 4, 725, DateTimeKind.Utc).AddTicks(8394), new Guid("c1dcd39f-4bec-4067-a7ec-1ecd0ea5205e"), null, 2, "Medium", new Guid("27f382d2-4ab0-479e-a8cf-e473ef454c01"), "Setup Navigation" },
                    { new Guid("f26285bc-d717-4fd7-85f5-a1da6b384ce8"), new Guid("90cce612-3658-4219-af21-ab5f41eedaed"), new Guid("708404f5-c420-4abe-baa6-b8e7aca4e2d5"), new DateTime(2025, 1, 3, 8, 2, 4, 725, DateTimeKind.Utc).AddTicks(8389), "Create responsive design for homepage", new DateTime(2025, 1, 10, 8, 2, 4, 725, DateTimeKind.Utc).AddTicks(8385), new Guid("c1dcd39f-4bec-4067-a7ec-1ecd0ea5205e"), null, 1, "High", new Guid("f21663ae-7a28-4b4e-901a-dbe7b881e7ed"), "Design Homepage" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblBoard_ProjectId",
                table: "tblBoard",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tblColumn_BoardId_Order",
                table: "tblColumn",
                columns: new[] { "BoardId", "Order" });

            migrationBuilder.CreateIndex(
                name: "IX_tblGoal_ProjectId_DueDate",
                table: "tblGoal",
                columns: new[] { "ProjectId", "DueDate" });

            migrationBuilder.CreateIndex(
                name: "IX_tblMilestone_GoalId_DueDate",
                table: "tblMilestone",
                columns: new[] { "GoalId", "DueDate" });

            migrationBuilder.CreateIndex(
                name: "IX_tblProject_OwnerId",
                table: "tblProject",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTask_AssigneeId",
                table: "tblTask",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTask_ColumnId_Order",
                table: "tblTask",
                columns: new[] { "ColumnId", "Order" });

            migrationBuilder.CreateIndex(
                name: "IX_tblTask_MilestoneId",
                table: "tblTask",
                column: "MilestoneId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTask_TagId",
                table: "tblTask",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_Email",
                table: "tblUser",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblTask");

            migrationBuilder.DropTable(
                name: "tblColumn");

            migrationBuilder.DropTable(
                name: "tblMilestone");

            migrationBuilder.DropTable(
                name: "tblTag");

            migrationBuilder.DropTable(
                name: "tblBoard");

            migrationBuilder.DropTable(
                name: "tblGoal");

            migrationBuilder.DropTable(
                name: "tblProject");

            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
