using InfrastructureLayer.DataAccess.Repositories.User;

namespace InfrastructureLayer.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}