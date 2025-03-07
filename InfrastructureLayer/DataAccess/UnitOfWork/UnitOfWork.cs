using DomainLayer.Models.User;
using InfrastructureLayer.DataAccess.Repositories.Common;

namespace InfrastructureLayer.DataAccess.UnitOfWork
{
    public class UnitOfWork
    {
        private AppDbContext db = new AppDbContext();
        public IBaseRepository<UserModel> UserRepository { get; private set; }
    }
}
