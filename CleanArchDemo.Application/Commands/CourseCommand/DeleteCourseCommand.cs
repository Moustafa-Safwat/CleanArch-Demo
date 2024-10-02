using CleanArchDemo.Application.Messaging;

namespace CleanArchDemo.Application.Commands.CourseCommand;

public sealed record DeleteCourseCommand(
    int Id):ICommand<(bool Success, string Message)>;
