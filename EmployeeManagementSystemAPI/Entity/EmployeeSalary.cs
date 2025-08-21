namespace EmployeeManagementSystemAPI.Entity
{
    public class EmployeeSalary
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Currency { get; set; } = string.Empty;        
        public Employee Employee { get; set; } = null!;// Navigation property to link to the Employee entity
    }
}
