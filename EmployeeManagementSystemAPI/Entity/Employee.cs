namespace EmployeeManagementSystemAPI.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public string Position { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }            
        public int? ManagerId { get; set; }
        public ICollection<EmployeeSalary> Salaries { get; set; } = new List<EmployeeSalary>(); // Navigation property to link to EmployeeSalary entities to gell ALL salary
        public Department Department { get; set; } = new Department();  // Navigation property to link to subordinates
    }
}
