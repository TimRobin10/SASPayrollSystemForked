using DomainLayer.Models.User;
using InfrastructureLayer.DataAccess.Repositories.User;
using ServicesLayer.Common;
using System.Linq.Expressions;


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

        public async Task AddAsync(UserModel entity)
        {
            await _userRepository.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<UserModel> entities)
        {
            await _userRepository.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync(Expression<Func<UserModel, bool>> filter = null, string? includeProperties = null)
        {
            var users = await _userRepository.GetAllAsync(filter, includeProperties);
            return users;
        }

        public async Task<UserModel> GetAsync(Expression<Func<UserModel, bool>> filter, string? includeProperties = null)
        {
            var user = await _userRepository.GetAsync(filter, includeProperties);
            return user;
        }

        public Task<IUserModel> Login(string text1, string text2)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(UserModel entity)
        {
            await _userRepository.RemoveAsync(entity);
        }

        public async Task RemoveRangeAsync(IEnumerable<UserModel> entities)
        {
            await _userRepository.RemoveRangeAsync(entities);
        }

        public async Task UpdateAsync(UserModel entity)
        {
            await _userRepository.UpdateAsync(entity);
        }

        public async Task UpdateRangeAsync(IEnumerable<UserModel> entities)
        {
            await _userRepository.UpdateRangeAsync(entities);
        }



        //public async Task AddNewUser(IUserModel userModel)
        //{
        //    var existingUser = await _userRepository
        //        .GetAsync(u => u.UserName == userModel.UserName || u.Email == userModel.Email);

        //    if (existingUser != null)
        //    {
        //        throw new UserNameOrEmailTakenException();
        //    }
        //    else
        //    {
        //        await _userRepository.AddAsync((UserModel)userModel);
        //    }
        //}

        //public async Task<UserModel> Login(string userName, string password)
        //{
        //    var user = await _userRepository
        //        .GetAsync(u => u.UserName == userName);

        //    if (user == null)
        //    {
        //        throw new UserNotFoundException();
        //    }
        //    else
        //    {
        //        var passwordBytes = Encoding.UTF8.GetBytes(password);
        //        var ePasswordBytes = EncryptSha256(passwordBytes);
        //        var saltedPasswordBytes = user.Salt.Concat(ePasswordBytes).ToArray();
        //        var finalHash = EncryptSha256(saltedPasswordBytes);

        //        if (!user.PasswordHash.SequenceEqual(finalHash))
        //            throw new IncorrectPasswordException();

        //        return user;
        //    }
        //}

        //private byte[] EncryptSha256(byte[] input)
        //{
        //    using (SHA256 sha256 = SHA256.Create())
        //    {
        //        return sha256.ComputeHash(input);
        //    }
        //}
        public void ValidateModelDataAnnotations(IUserModel userModel)
        {
            _modelDataAnnotationsCheck.ValidateModelDataAnnotations((UserModel)userModel);
        }
    }
}
