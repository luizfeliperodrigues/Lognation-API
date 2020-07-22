using Lognation.Domain.Common;
using Lognation.Domain.Entities;
using System.Threading.Tasks;

namespace Lognation.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> AnyAsync(int userId);

        Task<User> GetUserProfileAsync(int userId);

        Task UpdateProfileImageAsync(ProfileImage image);

        Task RemoveProfileImage(string profileImageId);
    }
}
