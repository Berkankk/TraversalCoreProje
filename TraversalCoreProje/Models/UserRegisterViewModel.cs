using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        [Compare("Password", ErrorMessage ="Şifreler Uyumlu Değil")]
        public string ConfirmPassword { get; set; }
    }
}
