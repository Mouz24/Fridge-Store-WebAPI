using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace FridgeProducts.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IAuthenticationManager _authManager;
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public TokenController(ILoggerManager logger, IAuthenticationManager authManager, IServiceManager serviceManager, IMapper mapper)
        {
            _logger = logger;
            _authManager = authManager;
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(TokensDTO tokensDTO)
        {
            if (tokensDTO is null)
            {
                _logger.LogError("TokensDTO object sent from client is null.");

                return BadRequest("TokensDTO object is null");
            }

            var accessToken = tokensDTO.AccessToken;

            var refreshToken = tokensDTO.RefreshToken;

            var username = _authManager.GetPrincipalFromExpiredToken(accessToken).Identity.Name;
            if (! await _authManager.ValidateExpiredTokenClaims(username, refreshToken))
            {
                return BadRequest("Invalid client request");
            }

            string newAccessToken = await _authManager.CreateAccessToken();
                
            string newRefreshToken = _authManager.CreateRefreshToken();

            _authManager.ReassignRefreshToken(newRefreshToken);

            await _serviceManager.SaveAsync();

            return Ok(new AuthenticatedResponse
            {
                Token = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }

        [HttpPost("revoke")]
        public async Task<IActionResult> Revoke()
        {
            var user = _mapper.Map<UserForAuthenticationDTO>(User);

            if (!await _authManager.ValidateUser(user))
            {
                return BadRequest();
            }

            await _authManager.RevokeRefreshToken(user.UserName);

            await _serviceManager.SaveAsync();

            return NoContent();
        }
    }
}
