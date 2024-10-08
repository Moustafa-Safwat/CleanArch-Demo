﻿using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Application.Mapping;
using CleanArchDemo.Core.Entities;
using CleanArchDemo.Core.Interfaces;

namespace CleanArchDemo.Application.Services
{
    /// <summary>
    /// Service for managing courses.
    /// </summary>
    /// <param name="courseRepository">The repository for course-related data operations.</param>
    public class CourseService(ICourseRepository courseRepository)
        : CurdService<CourseDto, Course>(courseRepository),
        ICourseService
    {
        /// <summary>
        /// Gets the students associated with a specific course ID.
        /// </summary>
        /// <param name="courseId">The ID of the course.</param>
        /// <returns>A queryable collection of <see cref="HumanDto"/> representing the students in the course.</returns>
        public IQueryable<HumanDto> GetStudentFromCourseId(int courseId)
        {
            return courseRepository.GetStudentsFromCourseId(courseId)
                .Select(student => student.MapObjects<Student, HumanDto>());
        }

        /// <summary>
        /// Gets the instructors associated with a specific course ID.
        /// </summary>
        /// <param name="courseId">The ID of the course.</param>
        /// <returns>A queryable collection of <see cref="HumanDto"/> representing the instructors in the course.</returns>
        public IQueryable<HumanDto> GetInstructorFromCourseId(int courseId)
        {
            return courseRepository.GetInstructorsFromCourseId(courseId)
                .Select(instructor => instructor.MapObjects<Instructor, HumanDto>());
        }

        /// <summary>
        /// Gets the department associated with a specific course ID asynchronously.
        /// </summary>
        /// <param name="courseId">The ID of the course.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the <see cref="DepartmentDto"/> associated with the course, or null if not found.</returns>
        public async Task<DepartmentDto?> GetDepartmentFromCourseIdAsync(int courseId)
        {
            var result = await courseRepository.GetDepartmentFromCourseIdAsyncAsync(courseId);
            return result?.MapObjects<Department, DepartmentDto>();
        }
    }
}
