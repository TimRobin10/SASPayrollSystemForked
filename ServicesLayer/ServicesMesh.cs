using DomainLayer;
using DomainLayer.Models.Attendance;
using DomainLayer.Models.Employee;
using DomainLayer.Models.Role;
using DomainLayer.Models.User;
using InfrastructureLayer.DataAccess.Repositories.Common;
using ServicesLayer.Common;
using ServicesLayer.Exceptions;
using System.Text;



namespace ServicesLayer
{
    public class ServicesMesh : IServicesMesh
    {
        public IUserModel? CurrentUser { get; private set; } = null;

        //Repositories
        private readonly IBaseRepository<UserModel> UserRepository;
        private readonly IBaseRepository<RoleModel> RoleRepository;
        private readonly IBaseRepository<EmployeeModel> EmployeeRepository;
        private readonly IBaseRepository<AttendanceModel> AttendanceRepository;

        //Common Services
        private IModelDataAnnotationsCheck _modelDataAnnotationsCheck;

        //Services List
        public IBaseServices<UserModel> UserServices { get; private set; }
        public IBaseServices<RoleModel> RoleServices { get; private set; }
        public IBaseServices<EmployeeModel> EmployeeServices { get; private set; }
        public IBaseServices<AttendanceModel> AttendanceServices { get; private set; }

        public ServicesMesh()
        {
            UserRepository ??= new BaseRepository<UserModel>();
            RoleRepository ??= new BaseRepository<RoleModel>();
            EmployeeRepository ??= new BaseRepository<EmployeeModel>();
            AttendanceRepository ??= new BaseRepository<AttendanceModel>();

            _modelDataAnnotationsCheck ??= new ModelDataAnnotationsCheck();

            UserServices ??= new BaseServices<UserModel>(UserRepository, _modelDataAnnotationsCheck);
            RoleServices ??= new BaseServices<RoleModel>(RoleRepository, _modelDataAnnotationsCheck);
            EmployeeServices ??= new BaseServices<EmployeeModel>(EmployeeRepository, _modelDataAnnotationsCheck);
            AttendanceServices ??= new BaseServices<AttendanceModel>(AttendanceRepository, _modelDataAnnotationsCheck);
        }



        public async Task AddNewUserWithRoleAsync(IUserModel newUser, string roleName)
        {
            this.UserServices.ValidateModelDataAnnotations((UserModel)newUser);
            var role = await RoleServices.GetAsync(r => r.NormalizedName == roleName.ToUpperInvariant().Trim()) 
                ?? throw new RoleNotFoundException();
            newUser.Roles.Add(role);
            role.Users.Add((UserModel)newUser);
            await UserServices.AddAsync((UserModel)newUser);
            await RoleServices.UpdateAsync(role);
        }

        public async Task<bool> LoginUser(string username, string password)
        {
            var user = await UserServices.GetAsync(u => u.UserName == username.Trim(), includeProperties: "Roles")
                ?? throw new UserNotFoundException();

            var saltedHashedPassword = Encryption.GenerateHash(password, user.Salt);

            if (!saltedHashedPassword.SequenceEqual(user.PasswordHash))
            {
                throw new IncorrectPasswordException();
            }
            else
            {
                CurrentUser = user;
                return true;
            }
        }
    }
}
