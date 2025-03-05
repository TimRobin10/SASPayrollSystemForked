using DomainLayer.Models.User;
using InfrastructureLayer.DataAccess.Repositories.User;
using InfrastructureLayer.DataAccess.UnitOfWork;
using ServicesLayer.Common;
using ServicesLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.User
{
    public class UserServices
    {
        private IUserRepository _userRepository;
        private IModelDataAnnotationsCheck _modelDataAnnotationsCheck;

        public UserServices(IUnitOfWork unitOfWork, IModelDataAnnotationsCheck modelDataAnnotationsCheck)
        {
            _userRepository = unitOfWork.UserRepository;
            _modelDataAnnotationsCheck = modelDataAnnotationsCheck;
        }

        public async Task AddAsync(IUserModel userModel)
        {
            var registeredUser = await _userRepository
                .GetAsync(u => u.UserName == userModel.UserName || u.Email == userModel.Email);

            if (registeredUser != null)
            {
                throw new UserNameOrEmailTaken();
            }
            else
            {
                await _userRepository.AddAsync((UserModel)userModel);
            }
        }
    }
}
