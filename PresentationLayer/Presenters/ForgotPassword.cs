using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class ForgotPasswordPresenter : BasePresenter, IForgotPasswordPresenter
    {
        private readonly IUserRepository _userRepository;

        public ForgotPasswordPresenter(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public bool SendPasswordResetLink(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                return false; // User not found
            }

            // Logic to send a password reset link
            return true;
        }
    }
}
