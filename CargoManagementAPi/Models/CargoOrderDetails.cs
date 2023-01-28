using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace CargoManagementAPi.Models
{
    public class CargoOrderDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        [Required]
        public string OrderId { get; set; }  

        public string ReceiverName { get; set; }

        [ForeignKey("Customer")]

        public int CustId { get; set; }

        [ForeignKey("Cargo")]
        public int CargoId { get; set; }

        public CargoType CargoType { get; set; }

        public int CargoTypeId { get; set; }

        public City City { get; set; }

        public int CityId { get; set; }

       


    }
}
