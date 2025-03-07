using DomainLayer.Models.Role;
using InfrastructureLayer.DataAccess.Repositories.Common;


namespace ServicesLayer.Role
{
    public interface IRoleServices : IBaseRepository<RoleModel>
    {
        public void ValidateModelDataAnnotations(IRoleModel roleModel);
    }
}
