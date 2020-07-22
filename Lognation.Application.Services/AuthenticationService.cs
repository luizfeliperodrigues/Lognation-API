using Lognation.Application.Services.Mappers;
using Lognation.DataContracts.DTO.Requests;
using Lognation.DataContracts.DTO.Responses;
using Lognation.Domain.Services;
using Lognation.Infra.CrossCutting.Security;
using System;
using System.Threading.Tasks;

namespace Lognation.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly ITokenGenerator _tokenGenerator;

        #endregion

        #region Constructor
        public AuthenticationService(IUserAuthenticationService userService, ITokenGenerator tokenGenerator)
        {
            this._userAuthenticationService = userService;
            this._tokenGenerator = tokenGenerator;
        }

        #endregion

        #region Public Methods

        public async Task SignUpAsync(SignUpRequestDTO request)
        {
            if (request == null || !request.IsValid())
            {
                throw new ArgumentException("Invalid User.");
            }

            var user = UserMapper.MapToDomain(request);

            await this._userAuthenticationService.SignUpAsync(user);
        }

        public async Task<AuthenticationResponseDTO> LoginAsync(AuthenticationRequestDTO request)
        {
            if (request == null || !request.IsValid())
            {
                throw new ArgumentException("Invalid Credentials Data.");
            }

            var user = await this._userAuthenticationService.LoginAsync(request.UserNameOrEmail, request.Password);

            var token = await this._tokenGenerator.GenerateTokenAsync(user.UserId, user.Email);

            var authentitcationResponse = new AuthenticationResponseDTO()
            {
                FirstName = user.User.FirstName,
                LastName = user.User.LastName,
                UserId = user.UserId,
                UserName = user.UserName,
                Token = token
            };

            return authentitcationResponse;
        }

        #endregion
    }
}
