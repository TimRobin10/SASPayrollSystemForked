using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class SignInPresenter : BasePresenter, ISignInPresenter
    {
        private readonly IUnitOfWork _unitOfWork;

        public SignInPresenter(IUnitOfWork servicesMesh)
        {
            _unitOfWork = servicesMesh;
        }

        public async Task AuthenticateUser(string userName, string password)
        {
            await _unitOfWork.LoginUser(userName, password);
        }
    }
}
