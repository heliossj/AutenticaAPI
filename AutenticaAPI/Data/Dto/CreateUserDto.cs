using System.ComponentModel.DataAnnotations;

namespace AutenticaAPI.Data.Dto
{
    public class CreateUserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; }
    }
}
