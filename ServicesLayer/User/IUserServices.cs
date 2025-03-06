using DomainLayer.Models.User;
using InfrastructureLayer.DataAccess.Repositories.User;


namespace ServicesLayer.User
{
    public interface IUserServices : IUserRepository
    {
        void ValidateModelDataAnnotations(IUserModel userModel);
    }
}