using CargoManagementAPi.IRepository;
using CargoManagementAPi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IRepository2<Customer> _repository2;
        public CustomersController(IRepository2<Customer> repository2)
        {
            _repository2 = repository2;
        }
        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAll()
        {
            return await _repository2.GetAll();
        }

        [HttpGet]
        [Route("GetCustomerById/{id}",Name = "GetCustomerById")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            var customer=await _repository2.GetById(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody]Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();

            }
            await _repository2.Create(customer);
            return CreatedAtRoute("GetCustomerById", new { id = customer.CustId }, customer);

        }
        [HttpPut]
        [Route("UpdateCustomer/{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result=await _repository2.Update(id, customer);
            if (result != null)
            {
                return NoContent();
            }
            return NotFound("Customer Not Found");
        }

        [HttpDelete("DeleteCustomer")]
        public async Task<ActionResult> Delete(int id)
        {
            var result=await _repository2.Delete(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Customer Not found with customer id:{id}");
        }





    }
}
