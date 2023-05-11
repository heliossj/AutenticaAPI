using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutenticaAPI.Data.Dto
{
    public class EditUserDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        //[EmailAddress]
        public string Email { get; set; }
    }
}
