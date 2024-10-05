using AutoMapper;
using CleanArchDemo.Application.Mapping.AutoMapper;

namespace CleanArchDemo.Application.Mapping;

public class AutoMapperConfiguration
{
    /// <summary>
    /// Registers the AutoMapper mappings.
    /// </summary>
    /// <returns>The configured MapperConfiguration.</returns>
    public static MapperConfiguration RegisterMappings()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new CommandsAndDtoMapping());
            cfg.AddProfile(new DtoAndEntitiesMapping());
        });
    }
}
