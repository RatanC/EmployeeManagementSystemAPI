using EmployeeManagementSystemAPI.DBContext;
using EmployeeManagementSystemAPI.Entity;
using EmployeeManagementSystemAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemAPI.Repositories
{
    public class EmployeeRepository(CvlContext cvlContext) : IEmployeeRepository
    {
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await cvlContext.Employees.Include(d => d.Department).Include(s => s.Salaries).ToListAsync();
        }
        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await cvlContext.Employees.Include(d => d.Department).Include(s => s.Salaries)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task CreateEmployeeAsync(Employee employee)
        {
            await cvlContext.Employees.AddAsync(employee);
        }

        public async Task<Employee?> UpdateEmployeeAsync(int id, Employee employee)
        {
            var existingEmployee = await cvlContext.Employees.Include(d => d.Department).Include(s => s.Salaries)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (existingEmployee == null)
            {
                return null;
            }
            existingEmployee.ManagerId = employee.ManagerId;
            existingEmployee.Position = employee.Position;
            cvlContext.Employees.Update(existingEmployee);
            return existingEmployee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await cvlContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }
            cvlContext.Employees.Remove(employee);
            return true;
        }
    }
}
