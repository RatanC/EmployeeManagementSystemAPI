using EmployeeManagementSystemAPI.Model;
using EmployeeManagementSystemAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/staff")]
    public class EmployeeController(IEmployeeService employeeService) : Controller
    {
        [HttpGet("getAll")]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var employeelist = await employeeService.GetAllEmployeesAsync();
            return Ok(employeelist);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetEmployeeAsync(int id)
        {
            var employee = await employeeService.GetEmployeeByIdAsync(id);
            return Ok(employee);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddEmployee(EmployeeModel employee)
        {
            var isAdded = await employeeService.CreateEmployeeAsync(employee);
            return Ok(isAdded);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteEmployeesAsync(int id)
        {
            var isDeleted = await employeeService.DeleteEmployeeAsync(id);
            return Ok(isDeleted);
        }

        [HttpPatch("update")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeModel employee)
        {
            var updatedEmployee = await employeeService.UpdateEmployeeAsync(id, employee);
            return Ok(updatedEmployee);
        }
    }
}
