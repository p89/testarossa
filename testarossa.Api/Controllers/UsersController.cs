using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testarossa.Infrastructure;
using testarossa.Infrastructure.Commands;
using testarossa.Infrastructure.Commands.Users;
using testarossa.Infrastructure.DTO;
using testarossa.Infrastructure.Services;

namespace testarossa.Api.Controllers
{
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }

        // GET api/values/5
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.Get(email);
            if (user == null)
                return NotFound();
            
            return new JsonResult(user);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            await _commandDispatcher.Dispatch(command);
            return Created($"users/{command.Email}", null);
        }

        
    }
}
