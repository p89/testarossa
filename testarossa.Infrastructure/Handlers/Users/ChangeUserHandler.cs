using System.Threading.Tasks;
using testarossa.Infrastructure.Commands;
using testarossa.Infrastructure.Commands.Users;
using testarossa.Infrastructure.Services;

namespace testarossa.Infrastructure.Handlers.Users
{
    public class ChangeUserHandler : ICommandHandler<ChangeUserPassword>
    {
        private readonly IUserService _userService;
        public ChangeUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle(ChangeUserPassword command)
        {
            throw new System.NotImplementedException();
        }
    }
}