using Microsoft.VisualBasic.ApplicationServices;
using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class SignUpPresenter : BasePresenter, ISignUpPresenter
    {
        private readonly IServicesMesh _servicesMesh;

        public SignUpPresenter(IServicesMesh servicesMesh)
        {
            _servicesMesh = servicesMesh;
        }
        public async Task NewUserRequest(string username, string password, string email)
        {
            await _servicesMesh.NewUserRequest(username, password, email);
        }
    }
}
