using DomainLayer.Models.User;
using InfrastructureLayer.DataAccess.Repositories.User;
using InfrastructureLayer.DataAccess.UnitOfWork;
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
    public class UserServices
    {
        private IUserRepository _userRepository;
        private IModelDataAnnotationsCheck _modelDataAnnotationsCheck;

        public UserServices(IUnitOfWork unitOfWork, IModelDataAnnotationsCheck modelDataAnnotationsCheck = null)
        {
            _userRepository = unitOfWork.UserRepository;
            _modelDataAnnotationsCheck = modelDataAnnotationsCheck;
        }

        public async Task AddUser(IUserModel userModel)
        {
            await _userRepository.AddAsync((UserModel)userModel);
        }
    }
}
