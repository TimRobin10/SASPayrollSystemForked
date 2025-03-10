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


        //To be refactored!
        public async Task AddNewUserWithRoleAsync(IUserModel newUser, string roleName)
        {

        }

        public async Task LoginUser(string username, string password)
        {
            var user = await UserServices.GetAsync(u => u.UserName == username.Trim(), includeProperties: "Role")
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
            var adminRole = await RoleServices.GetAsync(r => r.NormalizedName == "admin".ToUpperInvariant());
            var adminUser = await UserServices.GetAsync(u => u.Role == adminRole, includeProperties: "Role");

            if (adminUser == null)
            {
                adminUser = new UserModel()
                {
                    UserName = "admin",
                    Password = "password",
                    RoleId = adminRole.Id,
                    Role = adminRole
                };
                adminRole.Users.Add(adminUser);
                await RoleServices.UpdateAsync(adminRole);
            }
        }

        public async Task NewUserRequest(string username, string password, string email)
        {
            var userRequest = new NewUserRequestModel()
            {
                UserName = username,
                Password = password,
                Email = email
            };
            await NewUserRequestServices.AddAsync(userRequest);
        }

        public async Task ApproveNewUserRequest(string requestEmail, string roleName = null)
        {
            var requestModel = await NewUserRequestServices.GetAsync(r => r.Email == requestEmail)
                ?? throw new NewUserRequestNotFoundException();
            IRoleModel role;
            if (roleName != null)
            {
                role = await RoleServices.GetAsync(r => r.NormalizedName == roleName.Trim().ToUpperInvariant())
                    ?? throw new RoleNotFoundException();
            }
            else
            {
                role = await RoleServices.GetAsync(r => r.NormalizedName == "contractor".ToUpperInvariant());
            }
            var newUser = new UserModel(requestModel, role);
            role.Users.Add(newUser);
            await RoleServices.UpdateAsync((RoleModel)role);
        }
    }
}
