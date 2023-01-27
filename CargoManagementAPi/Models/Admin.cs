using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CargoManagementAPi.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DefaultValue("Admin@123")]

        public string Password { get; set; }
    }
}
