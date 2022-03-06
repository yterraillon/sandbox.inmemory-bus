using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublisherModule.Application;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new AwesomeEvent.Request("Wow"));
            return Ok(result);
        }

        [HttpGet("anothereventhandler")]
        public async Task<IActionResult> GetForAnotherEventhandler()
        {
            var result = await _mediator.Send(new AnotherEvent.Request());
            return Ok(result);
        }

        [HttpGet("andanother")]
        public async Task<IActionResult> GetForAndANother()
        {
            var result = await _mediator.Send(new AndAnotherHandler.Request());
            return Ok(result);
        }
    }
}
