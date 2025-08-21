using EmployeeManagementSystemAPI.Repositories;
using EmployeeManagementSystemAPI.Repositories.Interfaces;
using EmployeeManagementSystemAPI.UnitOfWorks.Interface;
using EmployeeManagementSystemAPI.UnitOfWorks;
using EmployeeManagementSystemAPI.Services;
using AutoMapper;

namespace EmployeeManagementSystemAPI.Extensions
{
    public static class ServiceExtensionCollection
    {
        public static IServiceCollection AddServiceExtensions(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
