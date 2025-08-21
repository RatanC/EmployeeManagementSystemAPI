using EmployeeManagementSystemAPI.DBContext;
using EmployeeManagementSystemAPI.Entity;
using EmployeeManagementSystemAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemAPI.Repositories
{
    public class DepartmentRepository(CvlContext cvlContext) : IDepartmentRepository
    {
        public async Task<IEnumerable<Department>> GetAllDepartmentAsync()
        {
            return await cvlContext.Department.ToListAsync();
        }
        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await cvlContext.Department.FindAsync(id);
        }
        public async Task<Department?> GetDepartmentByNameAsync(string name)
        {
            return await cvlContext.Department.FirstAsync(d => d.Name == name);
        }
    }
}
