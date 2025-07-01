using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyProject.WebUI.Models.UserModel
{
    public class UserRegisterViewModeL
    {
        [Display(Name = "Ad-Soyad")]
        public string? NameSurname { get; set; }


        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string UserName { get; set; }



        [Required(ErrorMessage = "E-posta gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Şifre Gereklidir.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

    }
}
