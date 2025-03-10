using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class SignUpPresenter : BasePresenter, ISignUpPresenter
    {
        private readonly IUserRepository _userRepository;

        public SignUpPresenter(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public bool RegisterUser(User newUser)
        {
            if (_userRepository.GetUserByEmail(newUser.Email) != null)
            {
                return false; // User already exists
            }

            _userRepository.AddUser(newUser);
            return true; // Registration successful
        }
    }
}
