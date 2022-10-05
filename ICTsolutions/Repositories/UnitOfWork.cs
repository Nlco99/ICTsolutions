using ICTsolutions.Core.IRepositories;
using ICTsolutions.Core.Repositories;

namespace ICTsolutions.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        public IUsersRepository User { get; }


        //implement constructor - inject IUserRepository and initialise variable (user)
        public UnitOfWork(IUsersRepository user)
        {
            User = user;
        }
    }
}
