namespace EmployeeManagementSystemAPI.Model
{
    public class EmployeeModel
    {
        public int? Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public decimal Salary { get; set; }
        public int ManagerId { get; set; } 

    }
}
