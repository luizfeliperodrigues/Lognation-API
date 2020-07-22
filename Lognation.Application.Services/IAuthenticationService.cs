using Lognation.DataContracts.DTO.Requests;
using Lognation.DataContracts.DTO.Responses;
using System.Threading.Tasks;

namespace Lognation.Application.Services
{
    public interface IAuthenticationService
    {
        Task SignUpAsync(SignUpRequestDTO request);

        Task<AuthenticationResponseDTO> LoginAsync(AuthenticationRequestDTO request);
    }
}
