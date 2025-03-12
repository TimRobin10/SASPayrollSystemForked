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
        private readonly IUnitOfWork _unitOfWork;

        public SignUpPresenter(IUnitOfWork servicesMesh)
        {
            _unitOfWork = servicesMesh;
        }
        public async Task NewUserRequest(string username, string password, string email)
        {
            await _unitOfWork.NewUserRequest(username, password, email);
        }
    }
}
