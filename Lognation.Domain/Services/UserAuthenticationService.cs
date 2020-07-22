using Lognation.Domain.Common;
using Lognation.Domain.Entities;
using Lognation.Domain.Repositories;
using Lognation.Infra.CrossCutting.Exceptions;
using System;
using System.Threading.Tasks;

namespace Lognation.Domain.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        private readonly ILoginRepository _loginRepository;

        private readonly IUnitOfWork _unitOfWork;

        public UserAuthenticationService(IUserRepository userRepository, ILoginRepository loginRepository, IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._loginRepository = loginRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task SignUpAsync(User userToRegister)
        {
            var loginExists = await this._loginRepository.AnyAsync(userToRegister.Login);

            if (loginExists)
            {
                throw new ConflictException("Conflict Username or Email;");
            }

            await this._userRepository.AddAsync(userToRegister);

            await this._unitOfWork.Commit();
        }

        public async Task<Login> LoginAsync(string userNameOrEmail, string password)
        {
            var foundUserLogin = await this._loginRepository.FindByLoginAsync(userNameOrEmail);

            if (foundUserLogin == null)
            {
                throw new UnauthorizedAccessException("User not found.");
            }

            foundUserLogin.ValidateAccess(password);

            return foundUserLogin;
        }
    }
}
