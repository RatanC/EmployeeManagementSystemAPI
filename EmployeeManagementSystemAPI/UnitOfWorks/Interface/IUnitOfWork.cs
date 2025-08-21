using EmployeeManagementSystemAPI.Repositories.Interfaces;

namespace EmployeeManagementSystemAPI.UnitOfWorks.Interface
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository Employees { get; }
        public IDepartmentRepository Departments { get; }
        Task<bool> SaveChangesAsync();
    }
}
 