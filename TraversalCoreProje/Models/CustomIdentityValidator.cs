using Microsoft.AspNetCore.Identity;

namespace TraversalCoreProje.Models
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        //Burası defaultta olan hataları kullanıcılara göstermek için kullanılıyor

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Parola minimum {length} karakter olmalıdır"
            };
        }


    }
}
