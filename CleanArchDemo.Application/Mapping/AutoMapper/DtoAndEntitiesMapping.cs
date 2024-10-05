using AutoMapper;
using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Core.Entities;

namespace CleanArchDemo.Application.Mapping.AutoMapper;

public class DtoAndEntitiesMapping : Profile
{
    public DtoAndEntitiesMapping()
    {
        CreateMap<CourseDto, Course>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Names))
            .ReverseMap();
        CreateMap<Student, HumanDto>()
            .ReverseMap();
    }
}
