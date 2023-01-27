using CargoManagementAPi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementAPi.IRepository
{
    public interface IRepository<T> where T : class
    {



        Task<ActionResult<IEnumerable<Cargo>>> GetAllCargo();
        Task<ActionResult<T>> GetCargoById(int id);
        Task<IActionResult> Create(T cargo);
        Task<T> Update(int cargoId, T cargo);
        Task<T> Delete(int cargoId);




    }
}
