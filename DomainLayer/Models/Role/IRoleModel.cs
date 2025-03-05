using DomainLayer.Models.User;

namespace DomainLayer.Models.Role
{
    public interface IRoleModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string NormalizedName { get; }
        ICollection<UserModel> Users { get; }
    }
}