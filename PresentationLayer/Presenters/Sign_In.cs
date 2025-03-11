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
        private readonly IServicesMesh _serviceMesh;

        public SignInPresenter(IServicesMesh servicesMesh)
        {
            _serviceMesh = servicesMesh;
        }

        public async Task AuthenticateUser(string userName, string password)
        {
            await _serviceMesh.LoginUser(userName, password);
        }
    }
}
