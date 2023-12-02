using System.ComponentModel.DataAnnotations;

namespace Test2FAApplication.Models
{
    public class UserModel
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? MobileNo { get; set; }
        //public bool TwoFactorEnabled { get; set; }
    }
}
