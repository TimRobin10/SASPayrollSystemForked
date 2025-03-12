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
    public interface IUnitOfWork
    {
        IBaseServices<AttendanceModel> AttendanceRepository { get; }
        IUserModel? CurrentUser { get; }
        IBaseServices<DepartmentModel> DepartmentRepository { get; }
        IBaseServices<EmployeeModel> EmployeeRepository { get; }
        IBaseServices<LeaveModel> LeaveRepository { get; }
        IBaseServices<NewUserRequestModel> NewUserRequestRepository { get; }
        IBaseServices<RoleModel> RoleRepository { get; }
        IBaseServices<UserModel> UserRepository { get; }

        Task ApproveNewUserRequest(string requestEmail, string roleName = null);
        Task InitialSeeding();
        Task LoginUser(string username, string password);
        Task NewUserRequest(string username, string password, string email);
        Task ForgotPasswordRequest(string username, string email, string password, string confirmPassword);
        void Save();
    }
}