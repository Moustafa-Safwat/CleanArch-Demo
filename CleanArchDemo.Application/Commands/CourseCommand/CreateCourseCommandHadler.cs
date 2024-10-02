using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Application.Messaging;
using CleanArchDemo.Core.Shared;

namespace CleanArchDemo.Application.Commands.CourseCommand;

public class CreateCourseCommandHadler(ICourseService courseService) : ICommandHandler<CreateCourseCommand, int>
{


    public async Task<Result<int>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        CourseDto courseDto = new()
        {
            Name = request.Name,
            Code = request.Code,
            Credits = request.Credits,
            Description = request.Description,
            DepartmentId = request.DepartmentId
        };
        var result = await courseService.AddAsync(courseDto, cancellationToken);
        if (result.IsFailure)
        {
            return result.AppendFailure(new(
                "CreateCourse.Failed",
                 "This Ccourse failed to be created"));
        }
        return Result<int>.Success(result.Value);
    }
}
