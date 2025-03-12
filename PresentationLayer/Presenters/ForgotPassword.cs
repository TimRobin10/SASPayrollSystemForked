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
        private readonly IUnitOfWork _unitOfWork;

        public ForgotPasswordPresenter(IUnitOfWork servicesMesh)
        {
            _unitOfWork = servicesMesh;   
        }

        /*public async bool SendPasswordResetLink(string email)
        {
            await 
        }*/
    }
}
