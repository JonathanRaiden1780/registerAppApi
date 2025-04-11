using ApiTest.Core.Contracts.Repositories;
using ApiTest.Core.Contracts.Repositories.Common;

namespace ApiTest.Core.Contracts.Factories.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryUsers RepositoryUsers { get; }
        void BeginTransaction();
        void CommitChanges();
        void RollbackChanges();

    }
}
