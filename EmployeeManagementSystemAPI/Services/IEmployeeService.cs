using EmployeeManagementSystemAPI.Model;

namespace EmployeeManagementSystemAPI.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync();
        Task<EmployeeModel> GetEmployeeByIdAsync(int id);
        Task<bool> CreateEmployeeAsync(EmployeeModel employeeModel);
        Task<EmployeeModel> UpdateEmployeeAsync(int id, EmployeeModel employeeModel);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
