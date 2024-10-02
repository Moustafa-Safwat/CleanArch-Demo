using CleanArchDemo.Application.Messaging;

namespace CleanArchDemo.Application.Commands.CourseCommand;

public sealed record DeleteCourseCommand(
    int id):ICommand<(bool Success, string Message)>;
