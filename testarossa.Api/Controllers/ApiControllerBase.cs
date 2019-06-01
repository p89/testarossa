using Microsoft.AspNetCore.Mvc;
using testarossa.Infrastructure.Commands;

namespace testarossa.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected ICommandDispatcher _commandDispatcher;
        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }
    }
}