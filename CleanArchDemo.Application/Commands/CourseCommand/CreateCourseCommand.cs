using CleanArchDemo.Application.Messaging;

namespace CleanArchDemo.Application.Commands.CourseCommand;
public sealed record CreateCourseCommand(
    string Name,
    string Code,
    int Credits,
    string Description,
    int DepartmentId) : ICommand<int>;
