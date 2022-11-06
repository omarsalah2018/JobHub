using JobHub.Application.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace JobHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CandidateController> _logger;
        public CandidateController(IMediator mediator, ILogger<CandidateController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost()]
        public async Task<IActionResult> Save([FromBody] SaveProfileCommand command)
        {
            bool result = false;
            try
            {
                result = _mediator.Send(command).Result;
                if (result == false)
                    return BadRequest("Some thing went wrong please try again");
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException, null);
                return BadRequest("Some thing went wrong please try again");
            }
            return Created("Saved Successfully", result);
        }

    }
}
