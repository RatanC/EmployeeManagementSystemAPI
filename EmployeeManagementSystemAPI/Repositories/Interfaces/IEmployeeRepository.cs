using EmployeeManagementSystemAPI.Entity;

namespace EmployeeManagementSystemAPI.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task CreateEmployeeAsync(Employee employee);
        Task<Employee?> UpdateEmployeeAsync(int id, Employee employee);  
        Task<bool> DeleteEmployeeAsync(int id);

    }
}
