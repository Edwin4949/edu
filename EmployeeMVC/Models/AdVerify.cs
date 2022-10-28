using System.ComponentModel.DataAnnotations;

namespace EmployeeMVC.Models
{
    public class AdVerify
    {
        [Key]
        public string username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];

        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }


    }  
}
