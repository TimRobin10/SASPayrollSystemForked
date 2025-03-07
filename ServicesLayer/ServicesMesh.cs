using DomainLayer.Models.Role;
using DomainLayer.Models.User;
using InfrastructureLayer.DataAccess.Repositories.Common;
using ServicesLayer.Common;
using ServicesLayer.Exceptions;
using ServicesLayer.Role;
using ServicesLayer.User;



namespace ServicesLayer
{
    public class ServicesMesh : IServicesMesh
    {
        //Repositories
        private readonly IBaseRepository<UserModel> UserRepository;
        private readonly IBaseRepository<RoleModel> RoleRepository;

        //Common Services
        private IModelDataAnnotationsCheck ModelDataAnnotationsCheck;

        //Services List
        public IUserServices UserServices { get; private set; }
        public IRoleServices RoleServices { get; private set; }

        public ServicesMesh()
        {
            UserRepository ??= new BaseRepository<UserModel>();
            RoleRepository ??= new BaseRepository<RoleModel>();

            ModelDataAnnotationsCheck ??= new ModelDataAnnotationsCheck();
            UserServices ??= new UserServices(UserRepository, ModelDataAnnotationsCheck);
            RoleServices ??= new RoleServices(RoleRepository, ModelDataAnnotationsCheck);
        }

        public async Task AddNewUserWithRole(IUserModel newUser, string roleName)
        {
            var role = await RoleServices.GetAsync(r => r.NormalizedName == roleName.ToUpperInvariant().Trim()) 
                ?? throw new RoleNotFoundException();
            newUser.Roles.Add(role);
            role.Users.Add((UserModel)newUser);
            await UserServices.AddAsync((UserModel)newUser);
            await RoleServices.UpdateAsync(role);
        }
    }
}
