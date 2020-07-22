using System.Threading.Tasks;

namespace Lognation.Infra.CrossCutting.Security
{
    public interface ITokenGenerator
    {
        Task<string> GenerateTokenAsync(int userId, string userEmail);

        Task<string> GetUserEmailFromTokenAsync(string rawToken);

        Task<bool> IsValidTokenAsync(string token);
    }
}
