using ApiEnglish.Application.CommandHandler.Auth;
using ApiEnglish.Application.DTOs.Auth;
using ApiEnglish.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiEnglish.API.Controllers.AuthController
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Register a new user in the system.
        /// </summary>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult> Register(
            [FromBody]RegisterRequest registerRequest)
        {
            var command = new RegisterCommand(
                registerRequest.Name,
                registerRequest.Username,
                registerRequest.Email,
                registerRequest.Password
            );
            
            Object? result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Login a user and return a JWT token if the credentials are valid.
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult> Login(
            [FromBody]LoginRequest loginRequest)
        {
            var command = new LoginCommand(
                loginRequest.Email,
                loginRequest.Password
            );

            Object? result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
