using ICTsolutions.Areas.Identity.Data;

namespace ICTsolutions.Core.Repositories
{
    public interface IUsersRepository
    {
        ICollection<ApplicationUser> GetUsers();


        //method that updates database
        ApplicationUser GetUser(string id);

        ApplicationUser UpdateUser(ApplicationUser user);
    }
}
