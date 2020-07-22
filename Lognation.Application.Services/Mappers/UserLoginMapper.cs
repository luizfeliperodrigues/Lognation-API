using Lognation.DataContracts.DTO;
using Lognation.Domain.Entities;

namespace Lognation.Application.Services.Mappers
{
    public static class UserLoginMapper
    {
        internal static Login MapToDomain(UserLoginDTO login)
        {
            return new Login()
            {
                Email = login.Email,
                UserName = login.UserName,
                Password = login.Password
            };
        }
    }
}
