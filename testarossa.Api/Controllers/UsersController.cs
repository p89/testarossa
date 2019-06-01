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
        public async Task<UserDTO> Get(string email)
        {
            return await _userService.Get(email);
        }

        [HttpPost("")]
        public async Task<IActionResult> Interia([FromBody] CreateUser command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok("O Boziu");
        }

        
    }
}
