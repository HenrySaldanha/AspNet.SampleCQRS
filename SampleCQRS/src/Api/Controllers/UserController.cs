using Api.Models.Request;
using Api.Models.Response;
using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("user")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="userRequest"> Represents the new user to be created </param>
        [HttpPost]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUserAsync(
            [FromServices] IMediator _mediator,
            [FromBody] CreateUserRequest userRequest)
        {
            UserResponse user = await _mediator.Send(new CreateUserCommand(userRequest));

            if (user == null)
                return BadRequest();

            return Created(nameof(CreateUserAsync), user);
        }

        /// <summary>
        /// Get user by uuid
        /// </summary>
        /// <param name="id"> Represents the user unique identifier </param>
        [HttpGet]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] IMediator _mediator,
            [FromQuery] Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            UserResponse result = await _mediator.Send(new GetUserQuery(id));
            return Ok(result);
        }
    }
}
