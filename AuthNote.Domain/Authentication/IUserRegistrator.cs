

namespace AuthNote.Domain.Authentication
{
    public interface IUserRegistrator
    {
        /// <summary>
        /// Registrate user in identity system
        /// </summary>
        /// <param name="userCredentials"></param>
        /// <returns>User identity id</returns>
        Task<string> Register(UserCredentials userCredentials);
    }
}
