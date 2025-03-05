using DomainLayer.Models.User;
using System.Threading.Tasks;

namespace ServicesLayer.User
{
    public interface IUserServices
    {
        Task AddNewUser(IUserModel userModel);
        Task<UserModel> Login(string userName, string password);
    }
}