using DomainLayer.Models.User;
using InfrastructureLayer.DataAccess.Repositories.Common;

namespace ServicesLayer.User
{
    public interface IUserServices : IBaseRepository<UserModel>
    {
        Task<IUserModel> Login(string text1, string text2);
        void ValidateModelDataAnnotations(IUserModel userModel);
    }
}