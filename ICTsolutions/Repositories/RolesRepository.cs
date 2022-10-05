using ICTsolutions.Areas.Identity.Data;
using ICTsolutions.Core.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace ICTsolutions.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private ApplicationDbContext _context;

        public RolesRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
