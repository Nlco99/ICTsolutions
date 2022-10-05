using ICTsolutions.Areas.Identity.Data;

namespace ICTsolutions.Core.Repositories
{
    public interface IUserRepository
    {
        ICollection<ApplicationUser> GetUsers();


        //method that updates database
        ApplicationUser GetUser(string id);
    }
}
