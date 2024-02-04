using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email Id")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
