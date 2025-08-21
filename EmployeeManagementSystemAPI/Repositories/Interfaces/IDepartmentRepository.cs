using EmployeeManagementSystemAPI.Entity;

namespace EmployeeManagementSystemAPI.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartmentAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task<Department?> GetDepartmentByNameAsync(string name);

    }
}
