using IdentityServer4.Models;
using System.ComponentModel.DataAnnotations;

namespace Api.Authentication.Models
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "O endereço de e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O endereço de e-mail não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
