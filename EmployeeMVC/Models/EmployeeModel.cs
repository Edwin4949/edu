using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeeMVC.Models
{
    public class EmployeeModel
    {
        public string? Title { get; set; }
        [Required(ErrorMessage = "Please enter your First Name"), MaxLength(10)]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your Last Name"), MaxLength(10)]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required]
        [Key]
        [Display(Name = "User Name")]
        public string? UserName { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string? Gender { get; set; } 
        
        [Required(ErrorMessage = "Enter the password"), MinLength(10)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Display(Name = "Email Id")]
        //[RegularExpression(@"^\w+([-+.']\w+)@\w+([-.]\w+)\.\w+([-.]\w+)*$", ErrorMessage = "Invalid Email")]
        public string? EmailId { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string? Country { get; set; }
        [Display(Name = "Mobile Number")]
        public string? MobileNumber { get; set; }
        [Required]
        [Display(Name = "Salary")]
        public double Salary { get; set; }
        [Required]
        [Display(Name = "Designation")]
        public string? Designation { get; set; }
        [Display(Name = "Image")]
        public string? Image { get; set; }
    }
    
}
