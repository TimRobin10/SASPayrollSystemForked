using DomainLayer.Models.Role;
using InfrastructureLayer.DataAccess.Repositories.Role;


namespace ServicesLayer.Role
{
    public interface IRoleServices : IRoleRepository
    {
        public void ValidateModelDataAnnotations(IRoleModel roleModel);
    }
}
