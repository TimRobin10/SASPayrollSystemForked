using DomainLayer.Common;
using DomainLayer.Models.Attendance;
using DomainLayer.Models.Department;
using DomainLayer.Models.Employee;
using DomainLayer.Models.Leave;
using DomainLayer.Models.NewUserRequest;
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
        private readonly IBaseRepository<AttendanceModel> AttendanceRepository;
        private readonly IBaseRepository<DepartmentModel> DepartmentRepository;
        private readonly IBaseRepository<EmployeeModel> EmployeeRepository;
        private readonly IBaseRepository<LeaveModel> LeaveRepository;
        private readonly IBaseRepository<NewUserRequestModel> NewUserRequestRepository;
        private readonly IBaseRepository<RoleModel> RoleRepository;
        private readonly IBaseRepository<UserModel> UserRepository;

        //Common Services
        private IModelDataAnnotationsCheck _modelDataAnnotationsCheck;

        //Services List
        public IBaseServices<AttendanceModel> AttendanceServices { get; private set; }
        public IBaseServices<DepartmentModel> DepartmentServices { get; private set; }
        public IBaseServices<EmployeeModel> EmployeeServices { get; private set; }
        public IBaseServices<LeaveModel> LeaveServices { get; private set; }
        public IBaseServices<NewUserRequestModel> NewUserRequestServices { get; private set; }
        public IBaseServices<RoleModel> RoleServices { get; private set; }
        public IBaseServices<UserModel> UserServices { get; private set; }

        public ServicesMesh()
        {
            AttendanceRepository ??= new BaseRepository<AttendanceModel>();
            DepartmentRepository ??= new BaseRepository<DepartmentModel>();
            EmployeeRepository ??= new BaseRepository<EmployeeModel>();
            LeaveRepository ??= new BaseRepository<LeaveModel>();
            NewUserRequestRepository ??= new BaseRepository<NewUserRequestModel>();
            RoleRepository ??= new BaseRepository<RoleModel>();
            UserRepository ??= new BaseRepository<UserModel>();

            _modelDataAnnotationsCheck ??= new ModelDataAnnotationsCheck();

            AttendanceServices ??= new BaseServices<AttendanceModel>(AttendanceRepository, _modelDataAnnotationsCheck);
            DepartmentServices ??= new BaseServices<DepartmentModel>(DepartmentRepository, _modelDataAnnotationsCheck);
            EmployeeServices ??= new BaseServices<EmployeeModel>(EmployeeRepository, _modelDataAnnotationsCheck);
            LeaveServices ??= new BaseServices<LeaveModel>(LeaveRepository, _modelDataAnnotationsCheck);
            NewUserRequestServices ??= new BaseServices<NewUserRequestModel>(NewUserRequestRepository, _modelDataAnnotationsCheck);
            RoleServices ??= new BaseServices<RoleModel>(RoleRepository, _modelDataAnnotationsCheck);
            UserServices ??= new BaseServices<UserModel>(UserRepository, _modelDataAnnotationsCheck);
        }



        public async Task AddNewUserWithRoleAsync(IUserModel newUser, string roleName)
        {
            this.UserServices.ValidateModelDataAnnotations((UserModel)newUser);
            var role = await RoleServices.GetAsync(r => r.NormalizedName == roleName.Trim().ToUpperInvariant(), includeProperties: "Users")
                ?? throw new RoleNotFoundException();
            await UserServices.AddAsync((UserModel)newUser);
            role.Users.Add((UserModel)newUser);
            newUser.Roles.Add(role);
            Task[] tasks =
            {
                UserServices.UpdateAsync((UserModel)newUser),
                RoleServices.UpdateAsync(role)
            };
            await Task.WhenAll(tasks);
        }

        public async Task LoginUser(string username, string password)
        {
            var user = await UserServices.GetAsync(u => u.UserName == username.Trim(), includeProperties: "Roles")
                ?? throw new UserNotFoundException();
            var encryption = new Encryption();
            var saltedHashedPassword = encryption.GenerateHash(password, user.Salt);

            if (!saltedHashedPassword.SequenceEqual(user.PasswordHash))
            {
                throw new IncorrectPasswordException();
            }
            else
            {
                CurrentUser = user;
            }
        }


        public async Task InitialSeeding()
        {
            await SeedRoles();
            await SeedAdmin();
        }
        private async Task SeedRoles()
        {
            string[] defaultRoles =
            {
                "admin",
                "employee",
                "contractor"
            };
            var roles = await RoleServices.GetAllAsync();
            var rolemodels = new List<RoleModel>();
            if (roles.Count() == 0)
            {
                foreach (var defaultRole in defaultRoles)
                {
                    var role = new RoleModel()
                    {
                        Name = defaultRole,
                    };
                    rolemodels.Add(role);
                }
            }
            await RoleServices.AddRangeAsync(rolemodels);
        }

        private async Task SeedAdmin()
        {
            var adminRole = await RoleServices.GetAsync(r => r.NormalizedName == "admin".ToUpperInvariant(), includeProperties: "Users");
            if (adminRole.Users.Count() == 0)
            {
                var adminUser = new UserModel()
                {
                    UserName = "admin",
                    Password = "password"
                };
                await UserServices.AddAsync(adminUser);
                adminUser.Roles.Add(adminRole);
                adminRole.Users.Add(adminUser);
                Task[] tasks =
                {
                    UserServices.UpdateAsync(adminUser),
                    RoleServices.UpdateAsync(adminRole)
                };
                await Task.WhenAll(tasks);
            }

            //Testing New User Requests
            
        }

        public async Task SignUpNewUser(string username, string password)
        {
            var userRequest = new NewUserRequestModel()
            {
                UserName = username,
                Password = password
            };
            await NewUserRequestServices.AddAsync(userRequest);
        }
    }
}
