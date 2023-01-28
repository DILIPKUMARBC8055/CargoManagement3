using CargoManagementAPi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementAPi.IRepository
{
    public class CustomerRepository : IRepository2<Customer>,IRepository5<City>
    {
        private readonly ApplicationDbContext _context2;
        private readonly ApplicationDbContext _context5;


        public CustomerRepository(ApplicationDbContext context2,ApplicationDbContext context5)
        {
            _context2 = context2;
            _context5 = context5;

        }

        

        public async Task<IActionResult> Create(Customer customer)
        {
            if (customer != null)
            {
                _context2.Customers.Add(customer);
                await _context2.SaveChangesAsync();
            }
            return null;
        }

        

        public async Task<Customer> Delete(int id)
        {
            var CustInDb = await _context2.Customers.FindAsync(id);
            if (CustInDb != null)
            {
                _context2.Remove(CustInDb);
                await _context2.SaveChangesAsync();
                return CustInDb;
            }
            return null;
            
        }

        public async Task<ActionResult<IEnumerable<Customer>>> GetAll()
        {
            return await _context2.Customers.ToListAsync();
        }

        

        public async Task<ActionResult<Customer>> GetById(int id)
        {
            var customer = await _context2.Customers.FindAsync(id);
            if (customer != null)
            {
                return customer;
            }
            return null;
        }

        public async Task<Customer> Update(int Custid, Customer customer)
        {
            var CustInDb = await _context2.Customers.FindAsync(Custid);
            if (CustInDb != null)
            {
                CustInDb.CustName = customer.CustName;
                CustInDb.CustAddress = customer.CustAddress;
                CustInDb.CustPhNo = customer.CustPhNo;
                CustInDb.CustEmail = customer.CustEmail;
                CustInDb.CustPassword = customer.CustPassword;
                _context2.Customers.Update(CustInDb);
                await _context2.SaveChangesAsync();
                return CustInDb;
               
                
            }
            return null;
        }

        //CRUD For cities

        public async Task<ActionResult<IEnumerable<City>>> GetAllCities()
        {
            return await _context5.Cities.ToListAsync();
            
        }
        public async Task<ActionResult<City>> CityById(int id)
        {
            var city = await _context5.Cities.FindAsync(id);
            if (city != null)
            {
                return city;
            }
            return null;
        }


        public async Task<IActionResult> Create(City city)
        {
            if (city != null)
            {
                _context5.Cities.Add(city);
                await _context5.SaveChangesAsync();

            }
            return null;
        }

        public async Task<City> Update(int id, City city)
        {
            var CityInDb = await _context5.Cities.FindAsync(id);
            if (CityInDb != null)
            {
                CityInDb.CityName = city.CityName;
                CityInDb.Pincode = city.Pincode;
                CityInDb.Country= city.Country;
                _context5.Cities.Update(CityInDb);
                await _context5.SaveChangesAsync();
                return CityInDb;
            }
            return null;
        }

        public async Task<City> Delete(int id)
        {
            var CityInDb = await _context5.Cities.FindAsync(id);
            if (CityInDb!= null)
            {
                _context5.Cities.Remove(CityInDb);
                await _context5.SaveChangesAsync();
                return CityInDb;
            }
            return null;
        }
    }
}
