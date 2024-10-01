using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Messaging;

namespace CleanArchDemo.Application.Queries;

public sealed record GetCourseByIdQuery(
    int Id) : IQuery<CourseDto>;
