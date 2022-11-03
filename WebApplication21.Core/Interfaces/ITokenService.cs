using WebApplication21.Core.Entities;

namespace WebApplication21.Core.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
