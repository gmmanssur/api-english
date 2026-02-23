using ApiEnglish.Application.CommandHandler.Auth;
using ApiEnglish.Application.DTOs.Auth;
using ApiEnglish.Application.Helper.Exceptions;
using MediatR;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Register(
            [FromBody]RegisterRequest registerRequest)
        {
            try
            {
                var command = new RegisterCommand(
                    registerRequest.Name,
                    registerRequest.Email,
                    registerRequest.Password,
                    registerRequest.ConfirmPassword
                );
                
                Object? result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                string filterMessage = ExceptionHelper.FilterExceptionMessage(ex.Message);
                return Unauthorized(new { message = filterMessage });
            }
            catch (Exception ex)
            {
                string filterMessage = ExceptionHelper.FilterExceptionMessage(ex.Message);
                return BadRequest(new { message = filterMessage });
            }
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
            try
            {
                var command = new LoginCommand(
                    loginRequest.Email,
                    loginRequest.Password
                );

                Object? result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                string filterMessage = ExceptionHelper.FilterExceptionMessage(ex.Message);
                return Unauthorized(new { message = filterMessage });
            }
            catch (Exception ex)
            {
                string filterMessage = ExceptionHelper.FilterExceptionMessage(ex.Message);
                return BadRequest(new { message = filterMessage });
            }
        }
    }
}
