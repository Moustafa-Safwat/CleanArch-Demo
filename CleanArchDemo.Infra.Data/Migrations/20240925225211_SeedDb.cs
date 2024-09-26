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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
