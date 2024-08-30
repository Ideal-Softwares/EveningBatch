using Microsoft.AspNetCore.Mvc;
using VRS.WebAPI.Data.Model;
using VRS.WebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VRS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return _employeeService.GetAll();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public int Post([FromBody] Employee employee)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                  return _employeeService.CreateEmployee(employee);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
