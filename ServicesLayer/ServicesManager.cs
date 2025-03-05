using InfrastructureLayer.DataAccess.Repositories.User;
using ServicesLayer.Common;
using ServicesLayer.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer
{
    public class ServicesManager : IServicesManager
    {
        //Repositories
        private IUserRepository UserRepository;

        //Common Services
        private IModelDataAnnotationsCheck ModelDataAnnotationsCheck;
        private bool disposedValue;

        //Services List
        public IUserServices UserServices { get; private set; }

        public ServicesManager()
        {
            UserRepository ??= new UserRepository();
            ModelDataAnnotationsCheck ??= new ModelDataAnnotationsCheck();
            UserServices ??= new UserServices(UserRepository, ModelDataAnnotationsCheck);
        }
    }
}
