using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testarossa.Infrastructure.Commands;
using testarossa.Infrastructure.Commands.Users;

namespace testarossa.Api.Controllers
{
    public class AccountsController : ApiControllerBase
    {
        public AccountsController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [HttpPut("")]
        [Route("password")]
        public async Task<IActionResult> Put([FromBody] ChangeUserPassword command)
        {
            await _commandDispatcher.Dispatch(command);
            return NoContent();
        }
    }
}