using AutoMapper;
using EmployeeManagementSystemAPI.Entity;
using EmployeeManagementSystemAPI.Model;

namespace EmployeeManagementSystemAPI.Extensions
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EmployeeModel, Employee>()
              .ForMember(dest => dest.Department, opt => opt.MapFrom(src => new Department { Name = src.Department }))
              .ForMember(dest => dest.DepartmentId, opt => opt.Ignore()) // You may want to resolve this from DB
              .ForMember(dest => dest.Salaries, opt => opt.Ignore()) // Handled manually in service
              .ReverseMap()
              .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
              .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => Convert.ToDecimal(src.Salaries.OrderByDescending(x=>x.EffectiveDate).FirstOrDefault()!.Salary)));
        }
    }
}
