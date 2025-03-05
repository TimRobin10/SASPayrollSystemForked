using InfrastructureLayer.DataAccess.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; private set; }

        public UnitOfWork()
        {
            UserRepository ??= new UserRepository();
        }
    }
}
