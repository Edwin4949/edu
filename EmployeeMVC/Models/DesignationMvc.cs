using System.ComponentModel.DataAnnotations;

namespace EmployeeMVC.Models
{
    public class DesignationMvc
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string? DesignationTypes { get; set; }

    }
}
