using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Application.Services;
using CleanArchDemo.Core.Entities;
using CleanArchDemo.Core.Interfaces;
using CleanArchDemo.Infra.Data.University.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchDemo.Infra.Ioc
{
    /// <summary>
    /// A static class that provides dependency registration for the application services.
    /// </summary>
    public static class DependenceyContainer
    {
        /// <summary>
        /// Registers the services in the dependency injection container.
        /// </summary>
        /// <param name="services">The service collection to register the services with.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICrudRepository<Course>), typeof(CurdRepository<Course>));
            services.AddScoped(typeof(ICrudRepository<Department>), typeof(CurdRepository<Department>));
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped(typeof(ICurdService<DepartmentDto>), typeof(CurdService<DepartmentDto, Department>));
            services.AddScoped<ICourseService, CourseService>();
            return services;
        }
    }
}
