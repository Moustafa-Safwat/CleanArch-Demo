using AutoMapper;
using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Application.Messaging;
using CleanArchDemo.Core.Shared;

namespace CleanArchDemo.Application.Commands.CourseCommand;

public class CreateCourseCommandHadler(ICourseService courseService, IMapper mapper) : ICommandHandler<CreateCourseCommand, int>
{


    public async Task<Result<int>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var courseDto = mapper.Map<CreateCourseCommand, CourseDto>(request);
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
