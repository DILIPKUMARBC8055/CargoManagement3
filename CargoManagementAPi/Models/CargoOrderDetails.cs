using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CargoManagementAPi.Models
{
    public class CargoOrderDetails
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustId { get; set; }

        [ForeignKey("Cargo")]
        public int CargoId { get; set; }
    }
}
