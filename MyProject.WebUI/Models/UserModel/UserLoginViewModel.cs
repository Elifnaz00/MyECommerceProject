using System.ComponentModel.DataAnnotations;

namespace MyProject.WebUI.Models.UserModel
{
    public class UserLoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        
        public bool RememberMe { get; set; } 



      
    }
}
