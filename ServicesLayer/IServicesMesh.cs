using DomainLayer.Models.Attendance;
using DomainLayer.Models.Department;
using DomainLayer.Models.Employee;
using DomainLayer.Models.Leave;
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
        IBaseServices<RoleModel> RoleServices { get; }
        IBaseServices<UserModel> UserServices { get; }

        Task AddNewUserWithRoleAsync(IUserModel newUser, string roleName);
        Task InitialSeeding();
        Task LoginUser(string username, string password);
    }
}