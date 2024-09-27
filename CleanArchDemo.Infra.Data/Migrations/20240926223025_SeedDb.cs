using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchDemo.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Courses_CoursesId",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Instructors_InstructorsId",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_EnrolledCoursesId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentsId",
                table: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "CourseStudent",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "EnrolledCoursesId",
                table: "CourseStudent",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                newName: "IX_CourseStudent_CourseId");

            migrationBuilder.RenameColumn(
                name: "InstructorsId",
                table: "CourseInstructor",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "CourseInstructor",
                newName: "InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseInstructor_InstructorsId",
                table: "CourseInstructor",
                newName: "IX_CourseInstructor_CourseId");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "CS", "Computer Science Department", "Computer Science" },
                    { 2, "MATH", "Mathematics Department", "Mathematics" },
                    { 3, "PHYS", "Physics Department", "Physics" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Code", "Credits", "DepartmentId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "CS101", 3, 1, "Basic programming course", "Introduction to Programming" },
                    { 2, "CS102", 3, 1, "Data structures course", "Data Structures" },
                    { 3, "MATH101", 4, 2, "Introduction to Calculus", "Calculus I" },
                    { 4, "MATH102", 3, 2, "Linear Algebra course", "Linear Algebra" },
                    { 5, "PHYS101", 4, 3, "Introduction to Classical Mechanics", "Classical Mechanics" },
                    { 6, "PHYS102", 4, 3, "Introduction to Quantum Physics", "Quantum Physics" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "DateOfBirth", "DepartmentId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "alice.johnson@example.com", "Alice", "Johnson", "1112223333" },
                    { 2, new DateTime(1975, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "bob.brown@example.com", "Bob", "Brown", "4445556666" },
                    { 3, new DateTime(1985, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "charlie.miller@example.com", "Charlie", "Miller", "7778889999" },
                    { 4, new DateTime(1990, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "diana.garcia@example.com", "Diana", "Garcia", "0001112222" },
                    { 5, new DateTime(1982, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "edward.martinez@example.com", "Edward", "Martinez", "3334445555" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "DepartmentId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "john.doe@example.com", "John", "Doe", "1234567890" },
                    { 2, new DateTime(2001, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "jane.smith@example.com", "Jane", "Smith", "0987654321" },
                    { 3, new DateTime(1999, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "michael.johnson@example.com", "Michael", "Johnson", "2223334444" },
                    { 4, new DateTime(2002, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "emily.davis@example.com", "Emily", "Davis", "5556667777" },
                    { 5, new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "david.wilson@example.com", "David", "Wilson", "8889990000" }
                });

            migrationBuilder.InsertData(
                table: "CourseInstructor",
                columns: new[] { "CourseId", "InstructorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 3 },
                    { 6, 3 },
                    { 1, 4 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "CourseStudent",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 3 },
                    { 6, 3 },
                    { 1, 4 },
                    { 3, 5 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Courses_CourseId",
                table: "CourseInstructor",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Instructors_InstructorId",
                table: "CourseInstructor",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_CourseId",
                table: "CourseStudent",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentId",
                table: "CourseStudent",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Courses_CourseId",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Instructors_InstructorId",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_CourseId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentId",
                table: "CourseStudent");

            migrationBuilder.DeleteData(
                table: "CourseInstructor",
                keyColumns: new[] { "CourseId", "InstructorId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CourseInstructor",
                keyColumns: new[] { "CourseId", "InstructorId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CourseInstructor",
                keyColumns: new[] { "CourseId", "InstructorId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CourseInstructor",
                keyColumns: new[] { "CourseId", "InstructorId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "CourseInstructor",
                keyColumns: new[] { "CourseId", "InstructorId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "CourseInstructor",
                keyColumns: new[] { "CourseId", "InstructorId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "CourseInstructor",
                keyColumns: new[] { "CourseId", "InstructorId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CourseInstructor",
                keyColumns: new[] { "CourseId", "InstructorId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseStudent",
                newName: "StudentsId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "CourseStudent",
                newName: "EnrolledCoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_CourseId",
                table: "CourseStudent",
                newName: "IX_CourseStudent_StudentsId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseInstructor",
                newName: "InstructorsId");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "CourseInstructor",
                newName: "CoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseInstructor_CourseId",
                table: "CourseInstructor",
                newName: "IX_CourseInstructor_InstructorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Courses_CoursesId",
                table: "CourseInstructor",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Instructors_InstructorsId",
                table: "CourseInstructor",
                column: "InstructorsId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_EnrolledCoursesId",
                table: "CourseStudent",
                column: "EnrolledCoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentsId",
                table: "CourseStudent",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
