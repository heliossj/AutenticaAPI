using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutenticaAPI.Data.Dto
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        //[EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Compare(nameof(Password), ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; }
    }
}
