using CargoManagementAPi.IRepository;
using CargoManagementAPi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : Controller
    {
        private readonly IRepository2<Customer> _repository2;
        private readonly IRepository3<Admin> _repository3;
        public AdminsController(IRepository3<Admin> repository, IRepository2<Customer> repository2)
        {

            _repository3 = repository;
            _repository2 = repository2;
        }


        //Admin CRUD operations
        [HttpGet]
        [Route("GetAllAdmin")]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAll()
        {
            return await _repository3.GetAll();

        }
        [HttpGet]
        [Route("GetAdminById/{id}",Name = "GetAdminById")]
        public async Task<ActionResult<Admin>> GetById(int id)
        {
            var admin= await _repository3.GetById(id);
            if(admin!=null)
            {
                return Ok(admin);
            }
            return NotFound();

        }
        [HttpPost]
        [Route("CreateAdmin")]
        public async Task<IActionResult> Create([FromBody]Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _repository3.Create(admin);
            return CreatedAtRoute("GetAdminById", new {id=admin.Id},admin);
        }
        [HttpPut]
        [Route("UpdateAdmin/{id}")]
        public async Task<IActionResult> Update(int id, Admin admin)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result=await _repository3.Update(id,admin);
            if(result != null)
            {
                return NoContent();
            }
            return NotFound("Admin Not Found");
        }
        [HttpDelete]
        [Route("DeleteAdmin/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result=await _repository3.Delete(id);
            if (result != null)
            {
                return Ok();
            }
            return NotFound("Admin not found with this id");

        }

        //Getting customer

        //[HttpGet]
        //[Route("GetCustomerById/{id}", Name = "GetCustomerById")]
        //public async Task<ActionResult<Customer>> GetCustomerById(int id)
        //{
        //    var customer = await _repository2.GetById(id);
        //    if (customer != null)
        //    {
        //        return Ok(customer);
        //    }
        //    return NotFound();
        //}


        //Employees CRUD operations





    }
}
