using InfrastructureLayer.DataAccess.Repositories.Common;

namespace ServicesLayer.Common
{
    public interface IBaseServices<T> : IBaseRepository<T> where T : class
    {
        void ValidateModelDataAnnotations(T domainModel);
    }
}