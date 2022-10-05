using ICTsolutions.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace ICTsolutions.Core.IRepositories
{
    public interface IRolesRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
