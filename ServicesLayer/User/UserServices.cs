using DomainLayer.Models.User;
using InfrastructureLayer.DataAccess.Repositories.User;
using InfrastructureLayer.Exceptions;
using ServicesLayer.Common;
using ServicesLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.User
{
    public class UserServices : IUserServices
    {
        private IUserRepository _userRepository;
        private IModelDataAnnotationsCheck _modelDataAnnotationsCheck;

        public UserServices(IUserRepository userRepository, IModelDataAnnotationsCheck modelDataAnnotationsCheck)
        {
            _userRepository = userRepository;
            _modelDataAnnotationsCheck = modelDataAnnotationsCheck;
        }

        public async Task AddNewUser(IUserModel userModel)
        {
            var existingUser = await _userRepository
                .GetAsync(u => u.UserName == userModel.UserName || u.Email == userModel.Email);

            if (existingUser != null)
            {
                throw new UserNameOrEmailTakenException();
            }
            else
            {
                await _userRepository.AddAsync((UserModel)userModel);
            }
        }

        public async Task<UserModel> Login(string userName, string password)
        {
            var user = await _userRepository
                .GetAsync(u => u.UserName == userName);

            if (user == null)
            {
                throw new UserNotFoundException();
            }
            else
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var ePasswordBytes = EncryptSha256(passwordBytes);
                var saltedPasswordBytes = user.Salt.Concat(ePasswordBytes).ToArray();
                var finalHash = EncryptSha256(saltedPasswordBytes);

                if (!user.PasswordHash.SequenceEqual(finalHash))
                    throw new IncorrectPasswordException();

                return user;
            }
        }

        private byte[] EncryptSha256(byte[] input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(input);
            }
        }
        void ValidateModelDataAnnotations(IUserModel userModel)
        {
            _modelDataAnnotationsCheck.ValidateModelDataAnnotations((UserModel)userModel);
        }
    }
}
