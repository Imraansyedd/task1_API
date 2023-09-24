using Microsoft.AspNetCore.Mvc;
using Task1.Models;
using Task1.Repository;

namespace Task1.Controllers

    {
        [ApiController]
        [Route("api/[controller]")]
        public class EmployeeController : Controller
        {
            private readonly EmployeeRepository _employeeRepository;

            public EmployeeController(EmployeeRepository employeeRepository)
            {
                _employeeRepository = employeeRepository;
            }

            [HttpGet]
            [Route("all")]
            public ActionResult<IEnumerable<Employee>> GetEmployees()
            {
                var employees = _employeeRepository.GetAllEmployees();
                return Ok(employees);
            }
        }
    }
