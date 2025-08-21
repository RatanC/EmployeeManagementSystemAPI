using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystemAPI.Entity;

namespace EmployeeManagementSystemAPI.DBContext
{
    public class CvlContext : DbContext
    {
        public CvlContext(DbContextOptions<CvlContext> options) : base(options){ }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalary { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}
