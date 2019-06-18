using System.Threading.Tasks;
using testarossa.Infrastructure.DTO;

namespace testarossa.Infrastructure.Services
{
    public interface IUserService : IService
    {
         Task<UserDTO> Get(string email);
         Task Register(string email, string username, string password);
    }
}