using Lognation.DataContracts.DTO.Requests;
using Lognation.Domain.Entities;

namespace Lognation.Application.Services.Mappers
{
    public static class UserMapper
    {
        #region Map to Domain

        internal static User MapToDomain(SignUpRequestDTO request)
        {
            if (request == null)
            {
                return null;
            }

            return new User()
            {
                FirstName = request.BasicInfo.FirstName,
                LastName = request.BasicInfo.LastName,
                Login = UserLoginMapper.MapToDomain(request.Login)
            };
        }

        #endregion

        #region Map to Contract

        //internal static UserDTO MapToContract(User user)
        //{
        //var response = new UserDTO()
        //{

        //};

        //    return response;
        //}

        #endregion
    }
}
