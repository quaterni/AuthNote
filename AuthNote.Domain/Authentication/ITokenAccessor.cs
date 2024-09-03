
namespace AuthNote.Domain.Authentication
{
    public interface ITokenAccessor
    {
        Task<string> GetToken(UserCredentials userCredentials);
    }
}
