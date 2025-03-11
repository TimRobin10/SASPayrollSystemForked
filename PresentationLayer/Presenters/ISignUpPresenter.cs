
namespace PresentationLayer.Presenters
{
    public interface ISignUpPresenter
    {
        Task NewUserRequest(string username, string password, string email);
    }
}