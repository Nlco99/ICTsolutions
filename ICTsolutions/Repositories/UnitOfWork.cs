using ICTsolutions.Core.IRepositories;
using ICTsolutions.Core.Repositories;

namespace ICTsolutions.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        public IUsersRepository User { get; }

        public IRolesRepository Role { get; }

        //implement constructor - inject IUserRepository and initialise variable (user)
        public UnitOfWork(IUsersRepository user, IRolesRepository role)
        {
            User = user;
            Role = role;
        }
    }
}
