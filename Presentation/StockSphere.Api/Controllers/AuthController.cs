using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockSphere.Application.Feature.Command.Register;
using StockSphere.Application.Feature.Query.Login;

namespace StockSphere.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterCommandRequest registerCommandRequest)
        {
            RegisterCommandResponse registerCommandResponse = await _mediator.Send(registerCommandRequest);
            return Ok(registerCommandResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginQueryRequest loginQueryRequest)
        {
           LoginQueryResponse loginQueryResponse = await _mediator.Send(loginQueryRequest);
            return Ok(loginQueryResponse);
        }

    }
}
