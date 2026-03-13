using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITIApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StCourses",
                columns: table => new
                {
                    StId = table.Column<int>(type: "int", nullable: false),
                    CrsId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StCourses", x => new { x.StId, x.CrsId });
                    table.ForeignKey(
                        name: "FK_StCourses_Courses_CrsId",
                        column: x => x.CrsId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StCourses_Students_StId",
                        column: x => x.StId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSessionAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrsSessionId = table.Column<int>(type: "int", nullable: false),
                    StId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSessionAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSessionAttendances_Students_StId",
                        column: x => x.StId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSessios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CrsId = table.Column<int>(type: "int", nullable: false),
                    InsId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSessios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSessios_Courses_CrsId",
                        column: x => x.CrsId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    ManagedDepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_ManagedDepartmentId",
                        column: x => x.ManagedDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Location", "ManagerId", "Name" },
                values: new object[,]
                {
                    { 1, "Building A", null, "Computer Science" },
                    { 2, "Building B", null, "Mathematics" },
                    { 3, "Building C", null, "Physics" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Ali", "Hassan", "010-1111-2222" },
                    { 2, "Mona", "Ahmed", "011-2222-3333" },
                    { 3, "Khaled", "Ibrahim", "012-3333-4444" },
                    { 4, "Yasmine", "Omar", "010-4444-5555" },
                    { 5, "Tarek", "Samir", "011-5555-6666" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "DeptId", "FirstName", "LastName", "ManagedDepartmentId", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "Ahmed", "Ali", null, "010-1234-5678" },
                    { 2, 1, "Sara", "Mohamed", null, "011-2345-6789" },
                    { 3, 2, "Omar", "Hassan", null, "012-3456-7890" },
                    { 4, 3, "Nadia", "Kamal", null, "010-4567-8901" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "DepartmentId", "Duration", "InstructorId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 1, 40, 1, false, "C# Programming" },
                    { 2, 1, 35, 2, false, "Data Structures" },
                    { 3, 2, 45, 3, false, "Calculus I" },
                    { 4, 2, 30, 3, false, "Linear Algebra" },
                    { 5, 3, 40, 4, false, "Mechanics" }
                });

            migrationBuilder.InsertData(
                table: "CourseSessios",
                columns: new[] { "Id", "CrsId", "InsId", "IsDeleted", "SessionDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, false, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intro to C#" },
                    { 2, 1, 1, false, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "OOP Basics" },
                    { 3, 2, 2, false, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arrays & Lists" },
                    { 4, 3, 3, false, new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Limits" },
                    { 5, 4, 3, false, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vectors" },
                    { 6, 5, 4, false, new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Newton's Laws" }
                });

            migrationBuilder.InsertData(
                table: "StCourses",
                columns: new[] { "CrsId", "StId", "IsDeleted" },
                values: new object[,]
                {
                    { 1, 1, false },
                    { 2, 1, false },
                    { 1, 2, false },
                    { 2, 3, false },
                    { 5, 3, false },
                    { 3, 4, false },
                    { 4, 4, false },
                    { 4, 5, false }
                });

            migrationBuilder.InsertData(
                table: "CourseSessionAttendances",
                columns: new[] { "Id", "CrsSessionId", "Grade", "Notes", "StId" },
                values: new object[,]
                {
                    { 1, 1, 90, "Excellent", 1 },
                    { 2, 1, 75, "Good", 2 },
                    { 3, 2, 85, "Very Good", 1 },
                    { 4, 3, 70, null, 1 },
                    { 5, 3, 95, "Top scorer", 3 },
                    { 6, 4, 80, null, 4 },
                    { 7, 5, 88, "Good effort", 5 },
                    { 8, 6, 100, "Absent", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSessionAttendances_CrsSessionId",
                table: "CourseSessionAttendances",
                column: "CrsSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSessionAttendances_StId",
                table: "CourseSessionAttendances",
                column: "StId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSessios_CrsId",
                table: "CourseSessios",
                column: "CrsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSessios_InsId",
                table: "CourseSessios",
                column: "InsId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerId",
                table: "Departments",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DeptId",
                table: "Instructors",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_ManagedDepartmentId",
                table: "Instructors",
                column: "ManagedDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StCourses_CrsId",
                table: "StCourses",
                column: "CrsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSessionAttendances_CourseSessios_CrsSessionId",
                table: "CourseSessionAttendances",
                column: "CrsSessionId",
                principalTable: "CourseSessios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSessios_Instructors_InsId",
                table: "CourseSessios",
                column: "InsId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_ManagerId",
                table: "Departments",
                column: "ManagerId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_DeptId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_ManagedDepartmentId",
                table: "Instructors");

            migrationBuilder.DropTable(
                name: "CourseSessionAttendances");

            migrationBuilder.DropTable(
                name: "StCourses");

            migrationBuilder.DropTable(
                name: "CourseSessios");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
