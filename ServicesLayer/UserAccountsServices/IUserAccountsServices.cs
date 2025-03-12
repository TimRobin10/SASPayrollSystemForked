using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.UserAccountsServices
{
    public interface IUserAccountsServices
    {
        Task ApproveNewUserRequest(string requestEmail, string roleName = null);
        Task InitialSeeding();
        Task LoginUser(string username, string password);
        Task NewUserRequest(string username, string password, string email);
    }
}
