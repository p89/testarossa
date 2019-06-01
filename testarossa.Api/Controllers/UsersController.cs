using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testarossa.Infrastructure;
using testarossa.Infrastructure.Commands;
using testarossa.Infrastructure.Commands.Users;
using testarossa.Infrastructure.DTO;
using testarossa.Infrastructure.Services;

namespace testarossa.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICommandDispatcher _commandDispatcher;
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher)
        {
            _userService = userService;
            _commandDispatcher = commandDispatcher;
        }

        // GET api/values/5
        [HttpGet("{email}")]
        public async Task<UserDTO> Get(string email)
        {
            return await _userService.Get(email);
        }

        [HttpPost("")]
        public async Task<IActionResult> Interia([FromBody] CreateUser command)
        {
            await _commandDispatcher.Dispatch(command);
            //_userService.Register(command.Email, command.Username, command.Password);
            return Ok("O Boziu");
        }
    }
}
