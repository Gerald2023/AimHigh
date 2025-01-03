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
                        principalColumn: "Id");
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
                    { new Guid("019cd1a7-0156-4970-bf7b-5f400ff5a143"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milestone not started", 1, true, null, "Not Started" },
                    { new Guid("cadf4f1d-15da-446d-8de7-9763f84529b2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milestone completed", 3, true, null, "Completed" },
                    { new Guid("ef1634ea-b4ed-455e-a015-b63e6058f678"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milestone in progress", 2, true, null, "In Progress" }
                });

            migrationBuilder.InsertData(
                table: "tblPriority",
                columns: new[] { "Id", "ColorCode", "CreatedAt", "Description", "DisplayOrder", "IsActive", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("0a67b914-5e01-4e66-bb59-6d27f95ef957"), "#FF0000", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High priority", 3, true, null, "High" },
                    { new Guid("0e1822f2-99a3-4d16-9186-13a2eef774a4"), "#00FF00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Low priority", 1, true, null, "Low" },
                    { new Guid("9a74695a-bfd1-46bf-b6d0-99c40650bc6e"), "#FFFF00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medium priority", 2, true, null, "Medium" }
                });

            migrationBuilder.InsertData(
                table: "tblTag",
                columns: new[] { "Id", "Color", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("9f5baf7c-4283-4ae2-81d6-028176c013f4"), "#00FF00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Feature" },
                    { new Guid("dc7ca0d7-8bb4-4ef3-8a74-5b6e677f9c87"), "#FF0000", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bug" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "ModifiedAt", "Password" },
                values: new object[,]
                {
                    { new Guid("6fc8385a-4782-4cd0-9162-1c14e29880d0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "Doe", null, "75K3eLr+dx6JJFuJ7LwIpEpOFmwGZZkRiB84PURz6U8=" },
                    { new Guid("dd6e3868-2ded-4ef5-b56f-9224f6ebda75"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "Smith", null, "75K3eLr+dx6JJFuJ7LwIpEpOFmwGZZkRiB84PURz6U8=" }
                });

            migrationBuilder.InsertData(
                table: "tblProject",
                columns: new[] { "Id", "CreatedAt", "Description", "ModifiedAt", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("3df57df9-d100-47f9-9ae4-4e105f12e712"), new DateTime(2025, 1, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(8942), "Second project", null, "Project Beta", new Guid("dd6e3868-2ded-4ef5-b56f-9224f6ebda75") },
                    { new Guid("75a1a40a-5a9f-4352-8272-ad0e63ed7ab8"), new DateTime(2025, 1, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(8940), "First project", null, "Project Alpha", new Guid("6fc8385a-4782-4cd0-9162-1c14e29880d0") }
                });

            migrationBuilder.InsertData(
                table: "tblBoard",
                columns: new[] { "Id", "CreatedAt", "Description", "ModifiedAt", "Name", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("1bd3802b-69cf-4af2-a98e-8cc1c0be373d"), new DateTime(2025, 1, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(8969), "Sprint planning board", null, "Sprint Board", new Guid("3df57df9-d100-47f9-9ae4-4e105f12e712") },
                    { new Guid("acf38b32-9583-4f95-a637-8a13db7dfe7e"), new DateTime(2025, 1, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(8968), "Main project board", null, "Main Board", new Guid("75a1a40a-5a9f-4352-8272-ad0e63ed7ab8") }
                });

            migrationBuilder.InsertData(
                table: "tblGoal",
                columns: new[] { "Id", "CreatedAt", "Description", "DueDate", "ModifiedAt", "Progress", "ProjectId", "Title" },
                values: new object[,]
                {
                    { new Guid("13c60603-ea4a-4421-ac63-3ea3bc7a8c65"), new DateTime(2025, 1, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(9004), "First quarter objectives", new DateTime(2025, 4, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(8997), null, 0.0, new Guid("75a1a40a-5a9f-4352-8272-ad0e63ed7ab8"), "Q1 Goals" },
                    { new Guid("e00f02fa-ab86-46dc-8d28-f05bdc4c9845"), new DateTime(2025, 1, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(9006), "Second quarter objectives", new DateTime(2025, 7, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(9005), null, 0.0, new Guid("3df57df9-d100-47f9-9ae4-4e105f12e712"), "Q2 Goals" }
                });

            migrationBuilder.InsertData(
                table: "tblColumn",
                columns: new[] { "Id", "BoardId", "CreatedAt", "ModifiedAt", "Name", "Order", "WIPLimit" },
                values: new object[,]
                {
                    { new Guid("2793736b-faef-46df-b6f6-a02c59a725b1"), new Guid("acf38b32-9583-4f95-a637-8a13db7dfe7e"), new DateTime(2025, 1, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(9033), null, "Done", 3, null },
                    { new Guid("4d03991b-fa58-4a96-b080-5b6e05ec7d21"), new Guid("acf38b32-9583-4f95-a637-8a13db7dfe7e"), new DateTime(2025, 1, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(9032), null, "In Progress", 2, null },
                    { new Guid("a3f51342-eb10-4b6f-bb42-e9a726cc3ea3"), new Guid("acf38b32-9583-4f95-a637-8a13db7dfe7e"), new DateTime(2025, 1, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(9031), null, "To Do", 1, null }
                });

            migrationBuilder.InsertData(
                table: "tblMilestone",
                columns: new[] { "Id", "CreatedAt", "Description", "DueDate", "GoalId", "MilestoneStatusId", "ModifiedAt", "Title" },
                values: new object[,]
                {
                    { new Guid("2a5b501e-b53c-4027-8351-923cc5cb6875"), new DateTime(2025, 1, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(9056), "First sprint milestone", new DateTime(2025, 2, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(9055), new Guid("13c60603-ea4a-4421-ac63-3ea3bc7a8c65"), new Guid("019cd1a7-0156-4970-bf7b-5f400ff5a143"), null, "Sprint 1" },
                    { new Guid("526fcb90-921f-465c-a2a5-25c08965cb04"), new DateTime(2025, 1, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(9059), "Second sprint milestone", new DateTime(2025, 3, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(9058), new Guid("13c60603-ea4a-4421-ac63-3ea3bc7a8c65"), new Guid("019cd1a7-0156-4970-bf7b-5f400ff5a143"), null, "Sprint 2" }
                });

            migrationBuilder.InsertData(
                table: "tblTask",
                columns: new[] { "Id", "AssigneeId", "ColumnId", "CreatedAt", "Description", "DueDate", "MilestoneId", "ModifiedAt", "Order", "PriorityId", "TagId", "Title" },
                values: new object[,]
                {
                    { new Guid("03443b40-0a1f-4a8f-ad45-c19e73d5bfad"), new Guid("6fc8385a-4782-4cd0-9162-1c14e29880d0"), new Guid("a3f51342-eb10-4b6f-bb42-e9a726cc3ea3"), new DateTime(2025, 1, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(9086), "Set up project infrastructure", new DateTime(2025, 1, 10, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(9082), new Guid("2a5b501e-b53c-4027-8351-923cc5cb6875"), new DateTime(2025, 1, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(9086), 1, new Guid("9a74695a-bfd1-46bf-b6d0-99c40650bc6e"), new Guid("9f5baf7c-4283-4ae2-81d6-028176c013f4"), "Initial Setup" },
                    { new Guid("de4a3ca1-07b1-4b38-9751-ffa2363b8bd3"), new Guid("dd6e3868-2ded-4ef5-b56f-9224f6ebda75"), new Guid("4d03991b-fa58-4a96-b080-5b6e05ec7d21"), new DateTime(2025, 1, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(9091), "Resolve authentication issues", new DateTime(2025, 1, 6, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(9091), new Guid("2a5b501e-b53c-4027-8351-923cc5cb6875"), new DateTime(2025, 1, 3, 19, 24, 58, 475, DateTimeKind.Utc).AddTicks(9092), 1, new Guid("0a67b914-5e01-4e66-bb59-6d27f95ef957"), new Guid("dc7ca0d7-8bb4-4ef3-8a74-5b6e677f9c87"), "Fix Login Bug" }
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
