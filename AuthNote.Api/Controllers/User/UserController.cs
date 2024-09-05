using AuthNote.Domain.Authentication;
using AuthNote.Domain.Data.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthNote.Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserRegistrator _userRegistrator;
        private readonly ITokenAccessor _tokenAccessor;

        public UserController(
            IUserRepository userRepository, 
            IMapper mapper, 
            IUserRegistrator userRegistrator,
            ITokenAccessor tokenAccessor)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userRegistrator = userRegistrator;
            _tokenAccessor = tokenAccessor;
        }

        [HttpGet]
        [Authorize(Roles= Roles.Admin)]
        public async Task<ActionResult<ICollection<UserResponse>>> GetUsers()
        {
            var users = await _userRepository.GetUsers();

            return Ok(_mapper.Map<ICollection<UserResponse>>(users));
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserResponse>> Register([FromBody] UserRegistrationRequest userRegistrationRequest)
        {
            var identityId = await _userRegistrator.Register(
                new UserCredentials(
                    userRegistrationRequest.Username, 
                    userRegistrationRequest.Email, 
                    userRegistrationRequest.Password));

            var user = Domain.Models.User.Create(
                 userRegistrationRequest.Username,
                 userRegistrationRequest.Email,
                 identityId);
            await _userRepository.Add(user);

            return Ok(_mapper.Map<UserResponse>(user));
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            try
            {
                var token = await _tokenAccessor.GetToken(
                    new UserCredentials(
                        "",
                        userLoginRequest.Email,
                        userLoginRequest.Password));

                return Ok(token);
            }
            catch (ApplicationException e)
            {
                return Ok($"You are not logged. Message: {e.Message}");
            }
        }
    }
}
