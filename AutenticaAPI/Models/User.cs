using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AutenticaAPI.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public User(): base() { }
    }
}
