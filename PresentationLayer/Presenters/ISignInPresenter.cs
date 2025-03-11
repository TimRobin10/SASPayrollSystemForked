
namespace PresentationLayer.Presenters
{
    public interface ISignInPresenter
    {
        Task AuthenticateUser(string userName, string password);
    }
}