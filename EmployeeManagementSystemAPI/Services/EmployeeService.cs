using AutoMapper;
using EmployeeManagementSystemAPI.Entity;
using EmployeeManagementSystemAPI.Model;
using EmployeeManagementSystemAPI.UnitOfWorks.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemAPI.Services
{
    public class EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) : IEmployeeService
    {
        public async Task<bool> CreateEmployeeAsync(EmployeeModel employeeModel)
        {
            try
            {
                if (employeeModel == null)
                {
                    throw new ArgumentNullException(nameof(employeeModel), "Employee model cannot be null");
                }

                var department = await unitOfWork.Departments.GetDepartmentByNameAsync(employeeModel.Department);
                if (department == null)
                {
                    throw new KeyNotFoundException($"Department '{employeeModel.Department}' not found.");
                }
                var employeeEntity = mapper.Map<Employee>(employeeModel);
                employeeEntity.Salaries.Add(new EmployeeSalary() { Salary = employeeModel.Salary });
                employeeEntity.Department = department;
                await unitOfWork.Employees.CreateEmployeeAsync(employeeEntity);
                return await unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            await unitOfWork.Employees.DeleteEmployeeAsync(id);
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync()
        {
            var employeeList = await unitOfWork.Employees.GetAllEmployeesAsync();
            return mapper.Map<IEnumerable<EmployeeModel>>(employeeList);
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            var employee = await unitOfWork.Employees.GetEmployeeByIdAsync(id);
            return mapper.Map<EmployeeModel>(employee);
        }
        public async Task<EmployeeModel> UpdateEmployeeAsync(int id, EmployeeModel employeeModel)
        {
            var enitity = mapper.Map<Employee>(employeeModel);
            var updatedEmployeeEntity = await unitOfWork.Employees.UpdateEmployeeAsync(id, enitity);
            await unitOfWork.SaveChangesAsync();
            return mapper.Map<EmployeeModel>(updatedEmployeeEntity);
        }
    }
}
