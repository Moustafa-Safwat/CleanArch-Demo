using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Application.Messaging;
using CleanArchDemo.Core.Shared;

namespace CleanArchDemo.Application.Queries;

public class GetCourseByIdQueryHandler(ICourseService courseService) : IQueryHandler<GetCourseByIdQuery, CourseDto>
{
    public async Task<Result<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await courseService.GetByIdAsync(request.Id, cancellationToken);
        if (result == null)
        {
            return Result<CourseDto>.Failure(new(
                "Course.NotFound",
                $"The course with ID [{request.Id}] was not found"));
        }
        return Result<CourseDto>.Success(result);
    }
}
