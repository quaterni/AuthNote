using AuthNote.Domain.Data.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuthNote.Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<UserResponse>>> GetUsers()
        {
            var users = await _userRepository.GetUsers();

            return Ok(_mapper.Map<ICollection<UserResponse>>(users));
        }
    }
}
