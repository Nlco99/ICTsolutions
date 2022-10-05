using ICTsolutions.Areas.Identity.Data;
using ICTsolutions.Core.Repositories;


//Repository that returns all the users
namespace ICTsolutions.Repositories
{
    public class UserRepository : IUsersRepository
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

        public ApplicationUser GetUser(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
