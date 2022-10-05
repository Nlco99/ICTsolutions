//out of scope tutorial

using ICTsolutions.Core.Repositories;

namespace ICTsolutions.Core.IRepositories
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }

    }
}
