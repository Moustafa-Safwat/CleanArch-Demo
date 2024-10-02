using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Application.Messaging;
using CleanArchDemo.Application.Services;
using CleanArchDemo.Core.Interfaces;
using CleanArchDemo.Core.Shared;

namespace CleanArchDemo.Application.Commands.CourseCommand;

public class DeleteCourseCommandHandler(ICourseService courseService) : ICommandHandler<DeleteCourseCommand, (bool Success, string Message)>
{
    public async Task<Result<(bool Success, string Message)>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var result = await courseService.DeleteAsync(request.Id);
        if (result.IsFailure)
        {
            return result.AppendFailure(new(
                "Course.FailedRemove",
                $"The course with Id [{request.Id}] can't be removed"));
        }
        return Result<(bool Success, string Message)>.Success(result.Value);
    }
}
