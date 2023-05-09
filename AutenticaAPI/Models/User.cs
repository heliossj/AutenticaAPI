using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AutenticaAPI.Models
{
    public class User : IdentityUser
    {
        public User(): base() { }
    }
}
