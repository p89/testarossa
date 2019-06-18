using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using testarossa.Infrastructure;
using testarossa.Infrastructure.Commands;
using testarossa.Infrastructure.Commands.Users;
using testarossa.Infrastructure.DTO;
using testarossa.Infrastructure.Services;
using testarossa.Infrastructure.Settings;

namespace testarossa.Api.Controllers
{
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly GeneralSettings _settings;

        public UsersController(IUserService userService, 
            ICommandDispatcher commandDispatcher,
            GeneralSettings settings) : base(commandDispatcher)
        {
            _settings = settings;
            _userService = userService;
            Console.WriteLine(_settings.Name);
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
