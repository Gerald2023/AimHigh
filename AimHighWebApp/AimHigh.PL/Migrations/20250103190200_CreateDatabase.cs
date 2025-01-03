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
                name: "tblMilestoneStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMilestoneStatus_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPriority",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ColorCode = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPriority_Id", x => x.Id);
                });

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
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        column: x => x.UserId,
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
                    MilestoneStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_tblMilestone_tblMilestoneStatus",
                        column: x => x.MilestoneStatusId,
                        principalTable: "tblMilestoneStatus",
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
                    PriorityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true)
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
                        name: "FK_tblTask_tblPriority",
                        column: x => x.PriorityId,
                        principalTable: "tblPriority",
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
                table: "tblMilestoneStatus",
                columns: new[] { "Id", "CreatedAt", "Description", "DisplayOrder", "IsActive", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("b4040d49-4cd0-4c03-84c3-3972eb27eda9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milestone completed", 3, true, null, "Completed" },
                    { new Guid("ea9b2fa5-6dff-4d09-a9d1-828a0010e6b0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milestone not started", 1, true, null, "Not Started" },
                    { new Guid("f756a3d6-1b18-44b0-9bb3-f5158569cce1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milestone in progress", 2, true, null, "In Progress" }
                });

            migrationBuilder.InsertData(
                table: "tblPriority",
                columns: new[] { "Id", "ColorCode", "CreatedAt", "Description", "DisplayOrder", "IsActive", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("9a23b152-0af2-4ab1-95a8-e861ae304881"), "#FF0000", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High priority", 3, true, null, "High" },
                    { new Guid("d0524789-8ba9-4b25-a261-7994bf6455aa"), "#FFFF00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medium priority", 2, true, null, "Medium" },
                    { new Guid("df7ffb9e-b58a-4b91-a7d6-587bf8ad0e3e"), "#00FF00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Low priority", 1, true, null, "Low" }
                });

            migrationBuilder.InsertData(
                table: "tblTag",
                columns: new[] { "Id", "Color", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("397379a2-677d-4698-99ab-e7c9981f7855"), "#FF0000", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bug" },
                    { new Guid("97030249-9ade-4950-b911-7b641c785933"), "#00FF00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Feature" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "ModifiedAt", "Password" },
                values: new object[,]
                {
                    { new Guid("f6f63289-c9a9-488c-9fd4-264c5ef271b6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "Doe", null, "75K3eLr+dx6JJFuJ7LwIpEpOFmwGZZkRiB84PURz6U8=" },
                    { new Guid("f7abeec3-99c6-411d-b4cd-d7ae202abf58"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "Smith", null, "75K3eLr+dx6JJFuJ7LwIpEpOFmwGZZkRiB84PURz6U8=" }
                });

            migrationBuilder.InsertData(
                table: "tblProject",
                columns: new[] { "Id", "CreatedAt", "Description", "ModifiedAt", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("0d349673-ab12-4bf6-a1af-dc2e4b427ac3"), new DateTime(2025, 1, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5397), "Second project", null, "Project Beta", new Guid("f7abeec3-99c6-411d-b4cd-d7ae202abf58") },
                    { new Guid("95e8a120-65fe-4b35-933f-cb8f8071548d"), new DateTime(2025, 1, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5395), "First project", null, "Project Alpha", new Guid("f6f63289-c9a9-488c-9fd4-264c5ef271b6") }
                });

            migrationBuilder.InsertData(
                table: "tblBoard",
                columns: new[] { "Id", "CreatedAt", "Description", "ModifiedAt", "Name", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("11dca8c5-6bb7-41b1-b5ae-aecffdfd6e81"), new DateTime(2025, 1, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5424), "Sprint planning board", null, "Sprint Board", new Guid("0d349673-ab12-4bf6-a1af-dc2e4b427ac3") },
                    { new Guid("ee008b61-7d81-4b28-909f-d4026d19708b"), new DateTime(2025, 1, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5423), "Main project board", null, "Main Board", new Guid("95e8a120-65fe-4b35-933f-cb8f8071548d") }
                });

            migrationBuilder.InsertData(
                table: "tblGoal",
                columns: new[] { "Id", "CreatedAt", "Description", "DueDate", "ModifiedAt", "Progress", "ProjectId", "Title" },
                values: new object[,]
                {
                    { new Guid("9b88d847-3eaf-41da-a0c2-d3365693b021"), new DateTime(2025, 1, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5452), "First quarter objectives", new DateTime(2025, 4, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5446), null, 0.0, new Guid("95e8a120-65fe-4b35-933f-cb8f8071548d"), "Q1 Goals" },
                    { new Guid("d2e75232-d77b-4b8c-a225-1ed986b3fe5a"), new DateTime(2025, 1, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5454), "Second quarter objectives", new DateTime(2025, 7, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5453), null, 0.0, new Guid("0d349673-ab12-4bf6-a1af-dc2e4b427ac3"), "Q2 Goals" }
                });

            migrationBuilder.InsertData(
                table: "tblColumn",
                columns: new[] { "Id", "BoardId", "CreatedAt", "ModifiedAt", "Name", "Order", "WIPLimit" },
                values: new object[,]
                {
                    { new Guid("96fed779-44a0-4b9a-98de-3be19c925416"), new Guid("ee008b61-7d81-4b28-909f-d4026d19708b"), new DateTime(2025, 1, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5478), null, "To Do", 1, null },
                    { new Guid("b6d2c9b7-d114-4f9e-8fd0-b763c4537ae6"), new Guid("ee008b61-7d81-4b28-909f-d4026d19708b"), new DateTime(2025, 1, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5480), null, "Done", 3, null },
                    { new Guid("dc94c6fc-1516-4a64-ade3-36bf04a8a7fb"), new Guid("ee008b61-7d81-4b28-909f-d4026d19708b"), new DateTime(2025, 1, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5479), null, "In Progress", 2, null }
                });

            migrationBuilder.InsertData(
                table: "tblMilestone",
                columns: new[] { "Id", "CreatedAt", "Description", "DueDate", "GoalId", "MilestoneStatusId", "ModifiedAt", "Title" },
                values: new object[,]
                {
                    { new Guid("55be96bf-d411-4cac-9ace-96587adddd82"), new DateTime(2025, 1, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5503), "Second sprint milestone", new DateTime(2025, 3, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5503), new Guid("9b88d847-3eaf-41da-a0c2-d3365693b021"), new Guid("ea9b2fa5-6dff-4d09-a9d1-828a0010e6b0"), null, "Sprint 2" },
                    { new Guid("cd473337-85bd-4cec-8542-93264ba38679"), new DateTime(2025, 1, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5501), "First sprint milestone", new DateTime(2025, 2, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5500), new Guid("9b88d847-3eaf-41da-a0c2-d3365693b021"), new Guid("ea9b2fa5-6dff-4d09-a9d1-828a0010e6b0"), null, "Sprint 1" }
                });

            migrationBuilder.InsertData(
                table: "tblTask",
                columns: new[] { "Id", "AssigneeId", "ColumnId", "CreatedAt", "Description", "DueDate", "MilestoneId", "ModifiedAt", "Order", "PriorityId", "TagId", "Title" },
                values: new object[,]
                {
                    { new Guid("7d5a3a4d-56cb-4ea1-b4ad-d5b2c2114249"), new Guid("f7abeec3-99c6-411d-b4cd-d7ae202abf58"), new Guid("dc94c6fc-1516-4a64-ade3-36bf04a8a7fb"), new DateTime(2025, 1, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5537), "Resolve authentication issues", new DateTime(2025, 1, 6, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5536), new Guid("cd473337-85bd-4cec-8542-93264ba38679"), new DateTime(2025, 1, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5537), 1, new Guid("9a23b152-0af2-4ab1-95a8-e861ae304881"), new Guid("397379a2-677d-4698-99ab-e7c9981f7855"), "Fix Login Bug" },
                    { new Guid("af0c1ef3-015d-49aa-9b61-c45a58c02e57"), new Guid("f6f63289-c9a9-488c-9fd4-264c5ef271b6"), new Guid("96fed779-44a0-4b9a-98de-3be19c925416"), new DateTime(2025, 1, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5532), "Set up project infrastructure", new DateTime(2025, 1, 10, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5528), new Guid("cd473337-85bd-4cec-8542-93264ba38679"), new DateTime(2025, 1, 3, 19, 1, 59, 318, DateTimeKind.Utc).AddTicks(5532), 1, new Guid("d0524789-8ba9-4b25-a261-7994bf6455aa"), new Guid("97030249-9ade-4950-b911-7b641c785933"), "Initial Setup" }
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
                name: "IX_tblMilestone_MilestoneStatusId",
                table: "tblMilestone",
                column: "MilestoneStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMilestoneStatus_DisplayOrder",
                table: "tblMilestoneStatus",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_tblMilestoneStatus_Name",
                table: "tblMilestoneStatus",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblPriority_DisplayOrder",
                table: "tblPriority",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_tblPriority_Name",
                table: "tblPriority",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblProject_UserId",
                table: "tblProject",
                column: "UserId");

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
                name: "IX_tblTask_PriorityId",
                table: "tblTask",
                column: "PriorityId");

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
                name: "tblPriority");

            migrationBuilder.DropTable(
                name: "tblTag");

            migrationBuilder.DropTable(
                name: "tblBoard");

            migrationBuilder.DropTable(
                name: "tblGoal");

            migrationBuilder.DropTable(
                name: "tblMilestoneStatus");

            migrationBuilder.DropTable(
                name: "tblProject");

            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
