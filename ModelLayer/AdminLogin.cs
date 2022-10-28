using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class AdminLogin
    {
        [Required(ErrorMessage ="Please enter the User Name")]
        [Display(Name ="User Name")]
        public string? Username { get; set; }
        [Required(ErrorMessage ="Please enter the Password")]
        [Display(Name ="Password")]
        public string? Password { get; set; }

    }
}