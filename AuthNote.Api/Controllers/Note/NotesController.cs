using AuthNote.Domain.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthNote.Api.Controllers.Note
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public NotesController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetNotes()
        {
            var claimId = HttpContext.User.FindFirst("identityId");

            var user = await _userRepository.GetUserByIdentityId(claimId.Value);

            return Ok(user.Notes.Select(note => new {note.Title, note.Content}));
        } 
    }
}
