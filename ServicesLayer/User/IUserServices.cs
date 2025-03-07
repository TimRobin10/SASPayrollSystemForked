using DomainLayer.Models.User;
using InfrastructureLayer.DataAccess.Repositories.User;

namespace ServicesLayer.User
{
    public interface IUserServices : IUserRepository
    {
        Task<IUserModel> Login(string text1, string text2);
        void ValidateModelDataAnnotations(IUserModel userModel);
    }
}