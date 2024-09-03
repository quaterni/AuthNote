namespace AuthNote.Api.Controllers.User
{
    public record UserRegistrationRequest(string Username, string Email, string Password);
}
