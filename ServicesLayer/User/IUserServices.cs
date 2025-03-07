using DomainLayer.Models.User;
using InfrastructureLayer.DataAccess.Repositories.Common;


namespace ServicesLayer.User
{
    public interface IUserServices : IBaseRepository<UserModel>
    {
        void ValidateModelDataAnnotations(IUserModel userModel);
    }
}