using CargoManagementAPi.IRepository;
using CargoManagementAPi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementAPi.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IRepositoryEmployee<Employee> _repository2;
        public EmployeesController(IRepositoryEmployee<Employee> repository2)
        {
            _repository2 = repository2;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            return await _repository2.GetAll();
        }

        [HttpGet]
        [Route("GetEmployeeById/{id}", Name = "GetEmployeeById")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _repository2.GetById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            await _repository2.Create(employee);
            return CreatedAtRoute("GetEmployeeById", new { id = employee.EmpId }, employee);

        }
        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _repository2.Update(id, employee);
            if (result != null)
            {

                return NoContent();
            }
            return NotFound("Employee Not Found");
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _repository2.Delete(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Employee Not found with employee id:{id}");
        }
    }



}

