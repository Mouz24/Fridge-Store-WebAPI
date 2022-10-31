using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Xml.Linq;

namespace FridgeProducts.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;

        public AuthorizationController(ILoggerManager logger, IMapper mapper,
        UserManager<User> userManager, IRepositoryManager repository, IAuthenticationManager authManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _repository = repository;
            _authManager = authManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the UserForRegistrationDTO object");
                return UnprocessableEntity(ModelState);
            }

            var user = _mapper.Map<User>(userForRegistration);

           
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded && result.Errors.Count() > 0)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
            
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDTO user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
                
                return Unauthorized();
            }

            return Ok(new { Token = await _authManager.CreateToken() });
        }
    }
}