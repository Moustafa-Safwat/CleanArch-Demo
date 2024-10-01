using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Messaging;

namespace CleanArchDemo.Application.Queries;

public record GetCourseByIdQuery(
    int Id) : ICommand<CourseDto>;
