using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeeMVC.Models
{
    public class AdLogin
    {
        [Required(ErrorMessage = "Please enter the User Name")]
        [Display(Name = "User Name")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Please enter the Password")]
        [Display(Name = "Password")]
        public string? Password { get; set; }

    }
}
