using System.ComponentModel.DataAnnotations;

namespace FuelQuoteApp_p1.Models.Account
{
    public class Register
    {
        [Required(ErrorMessage = "UserName is required!")]
        [MaxLength(50, ErrorMessage = "Maximum characters allowed is 50!!")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is required!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [MaxLength(50, ErrorMessage = "Maximum characters allowed is 50!!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match!")]
        public string ConfirmPassword { get; set; }
    }
}
