using CargoManagementAPi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementAPi.IRepository
{
    public interface IRepository<T> where T : class
    {



        Task<ActionResult<IEnumerable<T>>> GetAllCargo();
        Task<ActionResult<T>> GetCargoById(int id);
        Task<IActionResult> Create(T cargo);
        Task<T> Update(int cargoId, T cargo);
        Task<T> Delete(int cargoId);




    }
    //Customers
    public interface IRepository2<T> where T : class
    {
        Task<ActionResult<T>> GetById(int id);
        Task<ActionResult<IEnumerable<T>>> GetAll();
        Task<IActionResult> Create(T customer);
        Task<T> Update(int Custid,T customer);
        Task<T> Delete(int id);

    }

    //Admin

    public interface IRepository3<T> where T : class
    {
        Task<ActionResult<T>> GetById(int id);
        Task<ActionResult<IEnumerable<T>>> GetAll();
        Task<IActionResult> Create(T customer);
        Task<T> Update(int id, T admin);
        Task<T> Delete(int id);
    }






}
