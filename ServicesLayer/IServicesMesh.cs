using DomainLayer.Models.Attendance;
using DomainLayer.Models.Department;
using DomainLayer.Models.Employee;
using DomainLayer.Models.Leave;
using DomainLayer.Models.NewUserRequest;
using DomainLayer.Models.Role;
using DomainLayer.Models.User;
using ServicesLayer.Common;

namespace ServicesLayer
{
    public interface IServicesMesh
    {
        IBaseServices<AttendanceModel> AttendanceServices { get; }
        IUserModel? CurrentUser { get; }
        IBaseServices<DepartmentModel> DepartmentServices { get; }
        IBaseServices<EmployeeModel> EmployeeServices { get; }
        IBaseServices<LeaveModel> LeaveServices { get; }
        IBaseServices<NewUserRequestModel> NewUserRequestServices { get; }
        IBaseServices<RoleModel> RoleServices { get; }
        IBaseServices<UserModel> UserServices { get; }

        Task AddNewUserWithRoleAsync(IUserModel newUser, string roleName);
        Task ApproveNewUserRequest(string requestEmail, string roleName = null);
        Task InitialSeeding();
        Task LoginUser(string username, string password);
        Task NewUserRequest(string username, string password, string email);
    }
}