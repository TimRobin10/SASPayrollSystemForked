using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class ForgotPasswordPresenter : BasePresenter
    {
        private readonly IServicesMesh _servicesMesh;

        public ForgotPasswordPresenter(IServicesMesh servicesMesh)
        {
            _servicesMesh = servicesMesh;   
        }

        /*public async bool SendPasswordResetLink(string email)
        {
            await 
        }*/
    }
}
