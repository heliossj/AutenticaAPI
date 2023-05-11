using AutenticaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AutenticaAPI.Repository
{
    public class RoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Role role)
        {
            var exist = _context.Roles.Any(u => u.Name.Equals(role.Name));
            if (exist)
                throw new Exception("Já existe uma função registrada com este nome");
            _context.Add<Role>(role);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
