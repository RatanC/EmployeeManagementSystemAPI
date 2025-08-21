using EmployeeManagementSystemAPI.DBContext;
using EmployeeManagementSystemAPI.Entity;
using EmployeeManagementSystemAPI.Repositories;
using EmployeeManagementSystemAPI.Repositories.Interfaces;
using EmployeeManagementSystemAPI.UnitOfWorks.Interface;

namespace EmployeeManagementSystemAPI.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CvlContext _cvlContext;
        public IEmployeeRepository Employees { get; private set; }
        public IDepartmentRepository Departments { get; private set; }
        public UnitOfWork(CvlContext cvlContext)
        {
            _cvlContext = cvlContext ?? throw new ArgumentNullException(nameof(cvlContext));
            Employees = new EmployeeRepository(_cvlContext);
            Departments = new DepartmentRepository(_cvlContext);
        }

        public async Task<bool> SaveChangesAsync()
        {
            var res = await _cvlContext.SaveChangesAsync();
            return res > 0;
        }
    }
}
