using DomainLayer.Models.Role;
using InfrastructureLayer.DataAccess.Repositories.Common;
using ServicesLayer.Common;
using System.Linq.Expressions;


namespace ServicesLayer.Role
{
    public class RoleServices : IRoleServices
    {
        private IBaseRepository<RoleModel> _roleRepository;
        private IModelDataAnnotationsCheck _modelDataAnnotationsCheck;

        public RoleServices(IBaseRepository<RoleModel> roleRepository, IModelDataAnnotationsCheck modelDataAnnotationsCheck)
        {
            _roleRepository = roleRepository;
            _modelDataAnnotationsCheck = modelDataAnnotationsCheck;
        }

        public async Task AddAsync(RoleModel entity)
        {
            await _roleRepository.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<RoleModel> entities)
        {
            await _roleRepository.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<RoleModel>> GetAllAsync(Expression<Func<RoleModel, bool>> filter = null, string? includeProperties = null)
        {
            return await _roleRepository.GetAllAsync(filter, includeProperties);
        }

        public async Task<RoleModel> GetAsync(Expression<Func<RoleModel, bool>> filter, string? includeProperties = null)
        {
            return await _roleRepository.GetAsync(filter, includeProperties);
        }

        public async Task RemoveAsync(RoleModel entity)
        {
            await _roleRepository.RemoveAsync(entity);
        }

        public async Task RemoveRangeAsync(IEnumerable<RoleModel> entities)
        {
            await _roleRepository.RemoveRangeAsync(entities);
        }

        public async Task UpdateAsync(RoleModel entity)
        {
            await _roleRepository.UpdateAsync(entity);
        }

        public async Task UpdateRangeAsync(IEnumerable<RoleModel> entities)
        {
            await _roleRepository.UpdateRangeAsync(entities);
        }

        public void ValidateModelDataAnnotations(IRoleModel roleModel)
        {
            _modelDataAnnotationsCheck.ValidateModelDataAnnotations((RoleModel)roleModel);
        }
    }
}
