using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutenticaAPI.Data.Dto
{
    public class RoleDto : IdentityRole
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; }
    }
}
