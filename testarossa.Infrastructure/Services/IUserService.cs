using testarossa.Infrastructure.DTO;

namespace testarossa.Infrastructure.Services
{
    public interface IUserService
    {
         UserDTO Get(string email);
         void Register(string email, string username, string password);
    }
}