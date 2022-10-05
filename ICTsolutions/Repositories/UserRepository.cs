using ICTsolutions.Areas.Identity.Data;
using ICTsolutions.Core.Repositories;


//Repository that returns all the users
namespace ICTsolutions.Repositories
{
    public class UserRepository : IUserRepository
    {
        public ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public ICollection<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
