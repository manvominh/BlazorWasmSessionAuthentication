using BlazorWasmSessionAuthentication.Application.Dtos;
using BlazorWasmSessionAuthentication.Application.Features.UserFeatures.Queries.GetAllUsers;
using BlazorWasmSessionAuthentication.Application.Features.UserFeatures.Queries.ValidateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasmSessionAuthentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            return Ok(await mediator.Send(new GetAllUsers()));
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserSession?>> Login([FromBody] LoginRequest loginRequest)
        {
            return Ok(await mediator.Send(new ValidateUser(loginRequest)));
        }
    }
}
