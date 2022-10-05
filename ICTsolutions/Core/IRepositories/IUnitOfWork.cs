using ICTsolutions.Core.Repositories;

namespace ICTsolutions.Core.IRepositories
{
    public interface IUnitOfWork
    {
        //out of scope tutorial
        IUsersRepository User { get; }

        IRolesRepository Role { get; }
    }
}
