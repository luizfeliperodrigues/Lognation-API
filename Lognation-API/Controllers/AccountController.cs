using Lognation.DataContracts.DTO.Responses;
using Lognation.DataContracts.DTO.Requests;
using Lognation.Infra.CrossCutting.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Lognation.Application.Services;

namespace Lognation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignupAsync([FromBody] SignUpRequestDTO request)
        {
            try
            {
                await this._authenticationService.SignUpAsync(request);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (ConflictException exception)
            {
                return Conflict(exception.Message);
            }

            return Ok();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticationRequestDTO request)
        {
            try
            {
                AuthenticationResponseDTO response = await this._authenticationService.LoginAsync(request);

                return Ok(response);
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid Credentials");
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
