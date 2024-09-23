using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen bu alanı doldurunuz!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz!")]
        public string Password { get; set; }
    }
}
