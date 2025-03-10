using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class SignInPresenter : BasePresenter, ISignInPresenter
    {
        private readonly IUserRepository _userRepository;

        public SignInPresenter(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public bool AuthenticateUser(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null || user.Password != password) // In real-world apps, use hashed passwords
            {
                return false; // Authentication failed
            }

            return true; // Authentication successful
        }
    }
}
