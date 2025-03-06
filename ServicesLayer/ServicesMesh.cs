using DomainLayer.Models.Role;
using DomainLayer.Models.User;
using InfrastructureLayer.DataAccess.Repositories.Role;
using InfrastructureLayer.DataAccess.Repositories.User;
using ServicesLayer.Common;
using ServicesLayer.Role;
using ServicesLayer.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer
{
    public class ServicesMesh : IServicesMesh
    {
        //Repositories
        private readonly IUserRepository UserRepository;
        private readonly IRoleRepository RoleRepository;

        //Common Services
        private IModelDataAnnotationsCheck ModelDataAnnotationsCheck;

        //Services List
        public IUserServices UserServices { get; private set; }
        public IRoleServices RoleServices { get; private set; }


        public ServicesMesh()
        {
            UserRepository ??= new UserRepository();
            RoleRepository ??= new RoleRepository();

            ModelDataAnnotationsCheck ??= new ModelDataAnnotationsCheck();
            UserServices ??= new UserServices(UserRepository, ModelDataAnnotationsCheck);
            RoleServices ??= new RoleServices(RoleRepository, ModelDataAnnotationsCheck);
        }

        private byte[] EncryptSha256(byte[] input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(input);
            }
        }
    }
}
