namespace EmployeeManagementSystemAPI.Entity
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Employee> employees { get; set; }  = new List<Employee>();
    }
}
