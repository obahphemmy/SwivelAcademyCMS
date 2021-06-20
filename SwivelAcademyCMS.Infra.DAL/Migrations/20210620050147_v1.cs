using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwivelAcademyCMS.Infra.DAL.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseUnit = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseUnit", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Title" },
                values: new object[,]
                {
                    { 1, 4, null, new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 338, DateTimeKind.Unspecified).AddTicks(3332), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 345, DateTimeKind.Unspecified).AddTicks(6732), new TimeSpan(0, 1, 0, 0, 0)), null, "Introduction to Programming Using C#" },
                    { 2, 3, null, new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 346, DateTimeKind.Unspecified).AddTicks(276), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 346, DateTimeKind.Unspecified).AddTicks(309), new TimeSpan(0, 1, 0, 0, 0)), null, "Algorithms" },
                    { 3, 2, null, new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 346, DateTimeKind.Unspecified).AddTicks(325), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 346, DateTimeKind.Unspecified).AddTicks(329), new TimeSpan(0, 1, 0, 0, 0)), null, "Human Computer Interaction (HCI)" },
                    { 4, 4, null, new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 346, DateTimeKind.Unspecified).AddTicks(509), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 346, DateTimeKind.Unspecified).AddTicks(517), new TimeSpan(0, 1, 0, 0, 0)), null, "Compiler Construction" },
                    { 5, 3, null, new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 346, DateTimeKind.Unspecified).AddTicks(526), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 346, DateTimeKind.Unspecified).AddTicks(529), new TimeSpan(0, 1, 0, 0, 0)), null, "Advanced Algebra" },
                    { 6, 1, null, new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 346, DateTimeKind.Unspecified).AddTicks(557), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 346, DateTimeKind.Unspecified).AddTicks(562), new TimeSpan(0, 1, 0, 0, 0)), null, "Statistics" },
                    { 7, 2, null, new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 346, DateTimeKind.Unspecified).AddTicks(570), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 346, DateTimeKind.Unspecified).AddTicks(574), new TimeSpan(0, 1, 0, 0, 0)), null, "Computer Operations" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "Firstname", "Lastname", "ModifiedBy" },
                values: new object[,]
                {
                    { 1, null, new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 350, DateTimeKind.Unspecified).AddTicks(852), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 350, DateTimeKind.Unspecified).AddTicks(918), new TimeSpan(0, 1, 0, 0, 0)), "James", "Stuart", null },
                    { 2, null, new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 350, DateTimeKind.Unspecified).AddTicks(3188), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 350, DateTimeKind.Unspecified).AddTicks(3219), new TimeSpan(0, 1, 0, 0, 0)), "Michael", "Oyelowo", null }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "Firstname", "Lastname", "ModifiedBy" },
                values: new object[,]
                {
                    { 1, null, new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 350, DateTimeKind.Unspecified).AddTicks(7014), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 350, DateTimeKind.Unspecified).AddTicks(7042), new TimeSpan(0, 1, 0, 0, 0)), "Adewale", "Rowland", null },
                    { 2, null, new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 350, DateTimeKind.Unspecified).AddTicks(9136), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 6, 20, 6, 1, 46, 350, DateTimeKind.Unspecified).AddTicks(9159), new TimeSpan(0, 1, 0, 0, 0)), "Festus", "Emeka", null }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CourseId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 5, 2 },
                    { 5, 6, 2 },
                    { 6, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "TeacherCourses",
                columns: new[] { "Id", "CourseId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 5, 2 },
                    { 5, 6, 2 },
                    { 6, 4, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_CourseId",
                table: "TeacherCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_TeacherId",
                table: "TeacherCourses",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
