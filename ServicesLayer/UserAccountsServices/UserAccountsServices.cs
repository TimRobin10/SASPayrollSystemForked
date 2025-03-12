using DomainLayer.Common;
using DomainLayer.Models.NewUserRequest;
using DomainLayer.Models.Role;
using DomainLayer.Models.User;
using InfrastructureLayer.DataAccess.Repositories.Common;
using ServicesLayer.Common;
using ServicesLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.UserAccountsServices
{
    public class UserAccountsServices : IUserAccountsServices
    {
        private readonly IBaseServices<UserModel> _userServices;
        private readonly IBaseServices<RoleModel> _roleServices;
        private readonly IBaseServices<NewUserRequestModel> _newUserRequestServices;

        private IUserModel _userModel;

        public UserAccountsServices(IBaseServices<UserModel> userServices, IBaseServices<RoleModel> roleServices, IBaseServices<NewUserRequestModel> newUserRequestServices, IUserModel userModel)
        {
            _userServices = userServices;
            _roleServices = roleServices;
            _newUserRequestServices = newUserRequestServices;

            _userModel = userModel;
        }

        public async Task LoginUser(string username, string password)
        {
            var user = await _userServices.GetAsync(u => u.UserName == username.Trim(), includeProperties: "Role")
                ?? throw new UserNotFoundException();
            var encryption = new Encryption();
            var saltedHashedPassword = encryption.GenerateHash(password, user.Salt);

            if (!saltedHashedPassword.SequenceEqual(user.PasswordHash))
            {
                throw new IncorrectPasswordException();
            }
            else
            {
                _userModel = user;
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
            var roles = await _roleServices.GetAllAsync();
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
            await _roleServices.AddRangeAsync(rolemodels);
        }

        private async Task SeedAdmin()
        {
            var adminRole = await _roleServices.GetAsync(r => r.NormalizedName == "admin".ToUpperInvariant());
            var adminUser = await _userServices.GetAsync(u => u.Role == adminRole, includeProperties: "Role");

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
                await _roleServices.UpdateAsync(adminRole);
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
            await _newUserRequestServices.AddAsync(userRequest);
        }

        public async Task ApproveNewUserRequest(string requestEmail, string roleName = null)
        {
            var requestModel = await _newUserRequestServices.GetAsync(r => r.Email == requestEmail)
                ?? throw new NewUserRequestNotFoundException();
            IRoleModel role;
            if (roleName != null)
            {
                role = await _roleServices.GetAsync(r => r.NormalizedName == roleName.Trim().ToUpperInvariant())
                    ?? throw new RoleNotFoundException();
            }
            else
            {
                role = await _roleServices.GetAsync(r => r.NormalizedName == "contractor".ToUpperInvariant());
            }
            var newUser = new UserModel(requestModel, role);
            role.Users.Add(newUser);
            await _roleServices.UpdateAsync((RoleModel)role);
        }
    }
}
