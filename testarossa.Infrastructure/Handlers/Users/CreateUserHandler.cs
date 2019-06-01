using System.Threading.Tasks;
using testarossa.Infrastructure.Commands;
using testarossa.Infrastructure.Commands.Users;
using testarossa.Infrastructure.Services;

namespace testarossa.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;
        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle(CreateUser command)
        {
            await _userService.Register(command.Email, command.Username, command.Password);
        }
    }
}