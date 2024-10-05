using AutoMapper;
using CleanArchDemo.Application.Commands.CourseCommand;
using CleanArchDemo.Application.Dtos;

namespace CleanArchDemo.Application.Mapping.AutoMapper;

public class CommandsAndDtoMapping : Profile
{
    public CommandsAndDtoMapping()
    {
        CreateMap<CreateCourseCommand, CourseDto>()
            .ForMember(dest => dest.Names, opt => opt.MapFrom(src => src.Name))
            .ReverseMap()
            .ConstructUsing(src => new CreateCourseCommand(
                src.Names,
                src.Code,
                src.Credits,
                src.Description,
                src.DepartmentId
            ));
    }
}
