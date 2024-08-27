using AuthNote.Domain.Models;

namespace AuthNote.Domain.Data.Abstractions
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetUsers();
    }
}
